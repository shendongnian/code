    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Text.RegularExpressions;
    namespace FileSearcher
    {
        class Program
        {
            static string searchValue = "Windows";
            static List<FileInfo> files = new List<FileInfo>();
    
            static void Main(string[] args)
            {
                string startFolder = @"C:\";
                DirectoryInfo diParent = new DirectoryInfo(startFolder);
    
                FindSearchValue(diParent);
    
                foreach (var file in files)
                {
                    Console.WriteLine("{0}", file.FullName);
                }
    
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }
    
    
            /// <summary>
            /// Recursive function that searches for a file that matches the criteria.
            /// If the file is not found, the current file is opened and it's contents is 
            /// scanned for search value.
            /// </summary>
            /// <param name="diParent">Current parent folder being searched.</param>
            private static void FindSearchValue(DirectoryInfo diParent)
            {
                FileInfo[] foundFiles = diParent.GetFiles("*.doc");
    
                foreach (var file in foundFiles)
                {
                    Console.WriteLine(file.FullName);
    
                    if (file.FullName.Contains(searchValue)) // There is a search string in a file name
                    {
                        files.Add(file);
                    }
                    else
                    {
                        string fileContents = File.ReadAllText(file.FullName);
    
                        if (fileContents.Contains(searchValue)) // Here you can use Regex.IsMatch(fileContents, searchValue)
                        {
                            files.Add(file);
                        }
                    }
                }
    
                foreach (var diChild in diParent.GetDirectories())
                {
                    try
                    {
                        FindSearchValue(diChild);
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine("ERROR: {0}", exc.Message);
                    }
                }
            }
        }
    }
   
