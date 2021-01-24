        private static void RenameDirectoryFiles()
        {
            string pathfile = @"M:\_downloads\";
            string[] filePaths = Directory.GetFiles(pathfile);
            foreach (string filePath in filePaths)
            {
                try
                {
                    string dire = Path.GetDirectoryName(filePath);
                    string name = Path.GetFileNameWithoutExtension(filePath);
                    string exte = Path.GetExtension(filePath);
                    File.Copy($"{filePath}", $"{pathfile}\\{name}-New{exte}");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error File Copy");
                }
            }
        }
