        public string PathResolver(string filename)
        {
            string[] paths = Environment.GetEnvironmentVariable("PATH").Split(';');
            foreach (string path in paths)
            {
                string fname = Path.Combine(path, filename);
                if (File.Exists(filename)) return fname;
            }
            return "";
        }
