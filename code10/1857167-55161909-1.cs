        private static string GetParent(string directoryPath, string parent)
        {
            DirectoryInfo directory = new DirectoryInfo(directoryPath);
            while (directory.Parent!=null)
            {
                if (directory.Parent.Name.ToLower() == parent.ToLower())
                {
                    return directory.Parent.FullName;
                }
                directory = directory.Parent;
            }
            return null;
        }
