        public static bool FolderExists(string directory)
        {
            if (new Uri(directory, UriKind.Absolute).IsUnc && !Connected)
                return false;
            return System.IO.Directory.Exists(directory);
        }
