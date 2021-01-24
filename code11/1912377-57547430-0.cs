     public static async Task DirectoryMoveToAsync(string sourceDirName, string destDirName, bool copySubDirs)
            {
                // Get the subdirectories for the specified directory.
                DirectoryInfo dir = new DirectoryInfo(sourceDirName);
    
                if (!dir.Exists)
                {
                    throw new DirectoryNotFoundException(
                        "Source directory does not exist or could not be found: "
                        + sourceDirName);
                
                }
    
                DirectoryInfo[] dirs = dir.GetDirectories();
                // If the destination directory doesn't exist, create it.
                if (!Directory.Exists(destDirName))
                {
                    Directory.CreateDirectory(destDirName);
                }
    
                // Get the files in the directory and copy them to the new location.
                FileInfo[] files = dir.GetFiles();          
    
                
                // Wrap a file copy and a File Delete in the same transaction
                TxFileManager fileMgr = new TxFileManager();
                using (TransactionScope scope1 = new TransactionScope())
                {               
                    int x = 0;
                    foreach (FileInfo file in files)
                    {
                        // Just for the test, what will happen to the files if an exception occurs
                        //*************************************************************
                        x++;
                        if (x == 10)
                        {
                            throw new FileNotFoundException();
                        }
                        //**************************************************************
                        
                        string temppath = Path.Combine(destDirName, file.Name);                 
                        if (fileMgr.FileExists(temppath))
                        {
                            fileMgr.Delete(temppath);
                        }
                        fileMgr.Move(file.FullName, temppath);                
                    }
    
                    scope1.Complete();
                }
               
    
                // If copying subdirectories, copy them and their contents to new location.
                if (copySubDirs)
                {
                    foreach (DirectoryInfo subdir in dirs)
                    {
                       string temppath = Path.Combine(destDirName, subdir.Name);
                       await DirectoryMoveToAsync(subdir.FullName, temppath, copySubDirs);
                    }
                }
                
            }
          
    
      private async void ButtonMove_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    this.Cursor = Cursors.Wait;
                    await Task.Run(() => DirectoryMoveToAsync(@"Files", @"moved", false)); //"."
                    MessageBox.Show("Moved");             
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Failed : " + ex.Message.ToString() );
                }
                finally
                {
                    Cursor = Cursors.Arrow;
                }
            }
