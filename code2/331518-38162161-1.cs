    string[] FindFiles(FolderBrowserDialog dialog, string pattern)
        {
            Regex regex = new Regex(pattern);
            List<string> files = new List<string>();
            var files=Directory.GetFiles(dialog.SelectedPath);
            for(int i = 0; i < files.Count(); i++)
            {
                bool found = regex.IsMatch(files[i]);
                if(found)
                {
                    files.Add(files[i]);
                }
            }
            return files.ToArray();
        }
