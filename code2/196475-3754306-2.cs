            string path = "C:\\";
            var result = new List<string>();
            string[] extensions = { ".mp3", ".wma", ".mp4", ".wav" };
            foreach (string file in Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories)
                .Where(s => extensions.Any(ext => ext == Path.GetExtension(s))))
                {
                result.Add(file);
                Console.WriteLine(file);
            }
