     public string GetAbsolutePath(string relativePath)
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            int lastIndex = path.LastIndexOf("bin", StringComparison.OrdinalIgnoreCase);
            string actualPath = path.Substring(0, lastIndex);
            string projectPath = new Uri(actualPath).LocalPath;
            string absolutePath = projectPath + relativePath;
            return absolutePath;
        }
