    using System;
    using System.IO;
    using System.Text;
    class Test 
    {
        public static void Main() 
        {
            string path = @"c:\temp\MyTest.txt";
    
            // Create the file if it exists.
            if (!File.Exists(path)) 
            {
                File.Create(path);
            }
    
            FileAttributes attributes = File.GetAttributes(path);
    
            if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                // Make the file RW
                attributes = RemoveAttribute(attributes, FileAttributes.ReadOnly);
                File.SetAttributes(path, attributes);
                Console.WriteLine("The {0} file is no longer RO.", path);
            } 
            else 
            {
                // Make the file RO
                File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Hidden);
                Console.WriteLine("The {0} file is now RO.", path);
            }
        }
    
        private static FileAttributes RemoveAttribute(FileAttributes attributes, FileAttributes attributesToRemove)
        {
            return attributes & ~attributesToRemove;
        }
    }
