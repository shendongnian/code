            string[] parentDirectory = Directory.GetDirectories("/yourpath");
            List<string> directories = new List<string>();
            
            foreach (var directory in parentDirectory)
            {
                // Notice I've created a DirectoryInfo variable.
                DirectoryInfo dirInfo = new DirectoryInfo(directory);
                
                // And likewise a name variable for storing the name.
                // If this is not added, only the first directory will
                // be captured in the loop; the rest won't.
                string name = dirInfo.Name;
                
                // Finally we add the directory name to our defined List.
                directories.Add(name);
            }
