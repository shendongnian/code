    private void DeleteDirectoryRecursive(string dir)
        {
            if (String.IsNullOrEmpty(dir)) return;
            try
            {
                using (var isoFiles = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    foreach (var file in isoFiles.GetFileNames(dir + "\\*"))
                    {
                        var filename = dir + "/" + file;
                        if (isoFiles.FileExists(filename))
                            isoFiles.DeleteFile(filename);
                    }
                    foreach (var subdir in isoFiles.GetDirectoryNames(dir))
                    {
                        var dirname = dir + subdir + "\\";
                        if (isoFiles.DirectoryExists(dirname))
                            DeleteDirectoryRecursive(dirname);
                    }
                    var currentDirname = dir.TrimEnd('\\');
                    if (isoFiles.DirectoryExists(currentDirname))
                        isoFiles.DeleteDirectory(currentDirname);
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
