    Assembly _assembly;
            _assembly = Assembly.GetExecutingAssembly();
            List<string> filenames = new List<string>();
            filenames = _assembly.GetManifestResourceNames().ToList<string>();
            List<string> txtFiles = new List<string>();
            for (int i = 0; i < filenames.Count(); i++)
            {
                string[] items = filenames.ToArray();
                if (items[i].ToString().EndsWith(".txt"))
                {
                    txtFiles.Add(items[i].ToString());
                }
            }
