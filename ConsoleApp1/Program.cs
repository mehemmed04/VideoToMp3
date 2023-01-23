using MediaToolkit;
using MediaToolkit.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var root = @"E:\Videos";
            //var destination = @"E:\Musics";

            string[] files = Directory.GetFiles(root);
            foreach (var file in files)
            {
                var newfile = file.Replace(".vob", ".mp3");
                newfile = newfile.Replace(".mpg", ".mp3");
                newfile = newfile.Replace("Videos", "Musics");
                var inputFile = new MediaFile { Filename = file };
                var outputFile = new MediaFile { Filename = newfile };
                using (var engine = new Engine())
                {
                    engine.GetMetadata(inputFile);
                    engine.Convert(inputFile, outputFile);
                }
                Console.WriteLine(file + " converted succesfully to " + newfile);
            }
        }
    }
}
