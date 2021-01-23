        internal static string GetFolder(string path)
        {
            var folder = System.IO.Directory.GetParent(path).FullName;
            if (!folder.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()))
            {
                folder += System.IO.Path.DirectorySeparatorChar;
            }
            return folder;
        }
