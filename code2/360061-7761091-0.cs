      public static string FindFolder(DirectoryInfo rootDirectory, string folderToFind, int currentDepth, int maxDepth)
        {
            if(currentDepth == maxDepth)
            {
                return null;
            }
            foreach(var directory in rootDirectory.GetDirectories())
            {
                Console.WriteLine(directory.FullName);
                if(directory.Name.Equals(folderToFind,StringComparison.OrdinalIgnoreCase))
                {
                    return directory.FullName;
                }
                string tempFindResult;
                if((tempFindResult = FindFolder(directory,folderToFind,++currentDepth,maxDepth)) != null)
                {
                    return tempFindResult;
                }
            }
            return null;
        }
