    static void Main(string[] args)
        {
            string bricscadFolder = @"C:\Program Files\Bricsys\";
            bool enableFormDebugging = true;
            if (args != null && args.Length > 1)
            {
                bricscadFolder = args[0];
                enableFormDebugging = args[1] == "true";
            }
            var folders = Directory.GetDirectories(bricscadFolder);
            foreach(var folder in folders)
            {
                string file = $"{folder}\\bricscad.exe.config";
                if (File.Exists(file))
                {
                    string content = File.ReadAllText(file);
                    string replacement = $"useLegacyV2RuntimeActivationPolicy=\"{(enableFormDebugging ? "true" : "false")}\"";
                    string pattern = @"useLegacyV2RuntimeActivationPolicy\s*=\s*""(true|false)""";
                    Regex regex = new Regex(pattern);
                    string result = regex.Replace(content, replacement);
                    try
                    {
                        File.WriteAllText(file, result);
                    }
                    catch(UnauthorizedAccessException e)
                    {
                        Console.Write($"{file} is protected! Give it Write permission for User.");
                        Console.ReadLine();
                    }
                }
            }
        }
