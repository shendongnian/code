    using System;
    using Microsoft.VisualBasic.FileIO;
    
    
    namespace ProgressDialogBox
    {
        class Program
        {
            static void Main(string[] args)
            {
                
                string sourcePath = @"c:\TestA\TestNew3";
                string destinationPath = @"c:\TestB\TestNew4";
    
                Console.WriteLine(@"Copying... {0} ... Please stand by ", sourcePath);
                FileSystem.CopyDirectory(sourcePath, destinationPath, UIOption.AllDialogs);
    
            }
        }
    }
