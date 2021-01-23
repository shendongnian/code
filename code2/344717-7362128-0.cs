                string sourceDir = @"c:\test";
            string destinationDir = @"c:\test1";
            try
            {
                // Ensure the source directory exists
                if (Directory.Exists(sourceDir) == true )
                {
                    // Ensure the destination directory doesn't already exist
                    if (Directory.Exists(destinationDir) == false)
                    {
                        // Perform the move
                        Directory.Move(sourceDir, destinationDir);
                    }
                    else
                    {
                        // Could provide the user the option to delete the existing directory
                        // before moving the source directory
                    }
                }
                else
                {
                    // Do something about the source directory not existing
                }
            }
            catch (Exception)
            {
                // TODO: Handle the exception that has been thrown
            }
