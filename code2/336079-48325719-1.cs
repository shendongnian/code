    /// AUTHOR : Norm Petroff 
    /// <summary>
    /// Takes the files from the PathFrom and copies them to the PathTo. 
    /// </summary>
    /// <param name="pathFrom"></param>
    /// <param name="pathTo"></param>
    /// <param name="filesOnly">Copies all files from each directory to the "PathTo" and removes directory.</param>
    static void CopyFiles(String pathFrom, String pathTo, Boolean filesOnly)
    {
        foreach(String file in Directory.GetFiles(pathFrom))
        {
            // Copy the current file to the new path. 
            File.Copy(file, Path.Combine(pathTo, Path.GetFileName(file)), true);
            // Get all the directories in the current path. 
            foreach (String directory in Directory.GetDirectories(pathFrom))
            { 
                // If files only is true then recursively get all the files. They will be all put in the original "PathTo" location 
                // without the directories they were in. 
                if (filesOnly)
                {
                    // Get the files from the current directory in the loop. 
                    CopyFiles(directory, pathTo, filesOnly);
                }
                else
                {
                    // Create a new path for the current directory in the new location.                      
                    var newDirectory = Path.Combine(pathTo, new DirectoryInfo(directory).Name);
                    // Copy the directory over to the new path location if it does not already exist. 
                    if (!Directory.Exists(newDirectory))
                    {
                        Directory.CreateDirectory(newDirectory);
                    }
                    // Call this routine again with the new path. 
                    CopyFiles(directory, newDirectory, filesOnly);
                }
            }
        }
    }
