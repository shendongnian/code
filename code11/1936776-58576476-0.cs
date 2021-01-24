    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    
    
    static class Files
    {
        static void CopyAll(string source, string target, List<string> extensions)
        {
    
            var sourceInfo = new DirectoryInfo(source);
            var targetInfo = new DirectoryInfo(target);
    
    
            if (!sourceInfo.Exists)
                throw new FileNotFoundException($"File \"{sourceInfo.FullName}\" does not exist!");
    
            CopyAll(sourceInfo, targetInfo, extensions);
    
        }
        static void CopyAll(DirectoryInfo sourceInfo, DirectoryInfo targetInfo, List<string> extensions)
        {
    
            Directory.CreateDirectory(targetInfo.FullName); //Creates directory if does not exist.
    
           
            //Get Files and Filter our extensions
            List<FileInfo> files = sourceInfo.EnumerateFiles()
                    .Where(file => extensions.Contains(Path.GetExtension(file.Name).ToLower())).ToList();
    
            foreach (FileInfo currentFile in files)
            {
                // Make full path to new file 
                string destination = Path.Combine(targetInfo.FullName, currentFile.Name);
                Console.WriteLine($"Copying {currentFile.Name} to {destination}");
    
    
                // fileInfo.CopyTo(target,overwrite)
                currentFile.CopyTo(destination, true);
            }
    
            //Now we handle directories and sub directories.
            foreach (DirectoryInfo SubDirInfo in sourceInfo.EnumerateDirectories())
            {
                //We have to create the source directories  in the the target directory if they do not exist
                DirectoryInfo TargetSubDir = targetInfo.CreateSubdirectory(SubDirInfo.Name);
    
                //Recursively call  this function to get the files from this sub directory and into the new sub directory
                CopyAll(SubDirInfo, TargetSubDir, extensions);
            }
    
    
        }
    
    
    
        static void Main(string[] args)
        {
            
            var extensions = new List<string> { ".jpg", ".png" };
            CopyAll("FoldersToCopyFrom", "FolderToCopyTo", extensions);
            //or 
            Console.Read();
    
        }
    }
