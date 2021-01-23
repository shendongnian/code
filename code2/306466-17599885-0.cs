        public static string GetRandomTempPath()
        {
            var tempDir = System.IO.Path.GetTempPath();
            string fullPath;
            do
            {
                var randomName = System.IO.Path.GetRandomFileName();
                fullPath = System.IO.Path.Combine(tempDir, randomName);
            }
            while (Directory.Exists(fullPath));
            return fullPath;
        }
