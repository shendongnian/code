        public static bool IsAbsolutePath(string path)
        {
            return !string.IsNullOrWhiteSpace(path) && path.IndexOfAny(Path.GetInvalidPathChars().ToArray()) == -1 && Path.IsPathRooted(path)
                && Path.GetPathRoot(path).Length > 2; // Accepts X:\ and \\UNC\PATH, rejects empty string, \ and X:
        }
