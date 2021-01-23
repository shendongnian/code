    FileAttributes attributes = File.GetAttributes(path);
    
            if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
            {
                // Show the file.
                attributes = RemoveAttribute(attributes, FileAttributes.Hidden);
                File.SetAttributes(path, attributes);
                Console.WriteLine("The {0} file is no longer hidden.", path);
            } 
            else 
            {
                // Hide the file.
                File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Hidden);
                Console.WriteLine("The {0} file is now hidden.", path);
            }
