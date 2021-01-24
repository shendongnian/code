                try
                {
                string tmpLoc = Path.Combine(_TempPath, "CurrentLogs");
                Directory.CreateDirectory(tmpLoc);
                DateTime FileAgeLimit = DateTime.Now.AddDays(-7);
                foreach (var filePath in Directory.GetFiles(@"C:\data\test"))
                {
                    if (File.GetLastWriteTime(filePath) < FileAgeLimit)
                    {
                        //
                        //If you make it in here you have a filePath for a file that's older than 7 days
                        //Do your work here
                        //
                    }
                }
                }
                catch (Exception ex)
                {
                    var e = ex;
                }
