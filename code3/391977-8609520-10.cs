    namespace ExtensionMethods
    {
        public static class DirectoryExtensions
        {
            public static List<DirectoryInfo> GetSubFolders(this DirectoryInfo rootFolder)
            {
                if (rootFolder == null)
                {
                    throw new ArgumentException("Root-Folder must not be null!", "rootFolder");
                }
    
                List<DirectoryInfo> subFolders = new List<DirectoryInfo>();
                AddSubFoldersRecursively(rootFolder, ref subFolders);
                return subFolders;
            }
    
            private static void AddSubFoldersRecursively(DirectoryInfo rootFolder, ref List<DirectoryInfo> allFolders)
            {
                try
                {
                    allFolders.Add(rootFolder);
                    foreach (DirectoryInfo subFolder in rootFolder.GetDirectories())
                    {
                        AddSubFoldersRecursively(subFolder, ref allFolders);
                    }
                }
                catch (UnauthorizedAccessException exUnauthorized)
                {
                    // go on 
                }
                catch (DirectoryNotFoundException exNotFound)
                {
                    // go on 
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
