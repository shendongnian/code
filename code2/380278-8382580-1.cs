        void FileCreatedOnLogFolder(object sender, FileSystemEventArgs e)
        {
            try
            {
                DirectoryInfo logsDir = new DirectoryInfo(@"C:\ProgramData\Hamoub\Log");
                var logFiles = logsDir.GetFiles("*TransferServiceTrace*.log");
                var orderedLogFiles = logFiles.OrderBy(e => e.CreationTime);
                if (orderedLogFiles.Count() > 1)
                {
                    Logger.Log("Maintenance is needed, More than 2 log files found", Severity.Verbose);
                    for (int i = 0; i < orderedLogFiles.Count() - 2; i++)
                    {
                        try
                        {
                            var toDeleteFile = (orderedLogFiles.ElementAt(i) as FileInfo);
                            if (toDeleteFile != null)
                            {
                                toDeleteFile.Delete();
                            }
                        }
                        catch (Exception)
                        {
                            Logger.Log("Can't delete log file " + (orderedLogFiles.ElementAt(i) as FileInfo).Name, Severity.Warning);
                        }
                    }
                    // Store last file as TransferService.Last.Log
                    (orderedLogFiles.ElementAt(orderedLogFiles.Count() - 2) as FileInfo).CopyTo(Path.Combine(logsDir.FullName, "TransferService.Last.Log"), true);
                    (orderedLogFiles.ElementAt(orderedLogFiles.Count() - 2) as FileInfo).Delete();
                }
            }
            catch (Exception ex)
            {
                Logger.Log("Error during folder maintenance. " + ex.Message, Severity.Warning);
            }
        }
