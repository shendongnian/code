    using System;
    using Microsoft.WindowsAPICodePack.Shell;
    class Program
    {
        static void Main()
        {
            var shellFile = ShellFile.FromFilePath(@"C:\path\to\some\file.jpg");
            var tags = (string[])shellFile.Properties.System.Keywords.ValueAsObject;
            tags = tags ?? new string[0];
            Console.WriteLine("Tags: {0}", String.Join("; ", tags));
            Console.ReadLine();
        }
    }
