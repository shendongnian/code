     using (ZipFile zip = ZipFile.Read(nextVersion + ".zip"))
                {
                    zip.ExtractAll(Directory.GetCurrentDirectory(), ExtractExistingFileAction.OverwriteSilently);
                    zip.Dispose();
                    try
                    {
                        File.Delete(nextVersion + ".zip");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Could not delete ZIP!");
                        Environment.Exit(1);
                    }
                }
