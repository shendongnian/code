            var newFiles = System.IO.Directory.GetFiles(updateLocation).Select(file => new FileInfo(file));
            var workingDirectory = Environment.CurrentDirectory;
            var existingFiles = System.IO.Directory.GetFiles(workingDirectory).Select(file => new FileInfo(file));
            newFiles.ToList().ForEach(newFile =>
            {
                var matchedFile = existingFiles.ToList().Find(delegate(FileInfo file) { return file.Name == newFile.Name; });
                if(matchedFile != null)
                {
                    if(newFile.LastWriteTimeUtc != matchedFile.LastWriteTimeUtc)
                    {
                        if(!Directory.Exists(TEMP_DIRECTORY_NAME))
                            Directory.CreateDirectory(TEMP_DIRECTORY_NAME);
                        matchedFile.MoveTo(Path.Combine(TEMP_DIRECTORY_NAME, matchedFile.Name));
                        newFile.CopyTo(Path.Combine(workingDirectory, newFile.Name));
                    }
                }
                else
                    newFile.CopyTo(Path.Combine(workingDirectory, newFile.Name));
            });'
