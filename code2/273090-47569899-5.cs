        public static bool IsFullPath(string path)
        {
            return !string.IsNullOrWhiteSpace(path) && path.IndexOfAny(Path.GetInvalidPathChars()) == -1 && Path.IsPathRooted(path)
                && Path.GetPathRoot(path).Length > 2; // Accepts X:\ and \\UNC\PATH, rejects empty string, \ and X:
        }
