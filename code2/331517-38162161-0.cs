    string[] FindFiles(FolderBrowserDialog dialog, string pattern)
        {
            Regex regex = new Regex(pattern);
            List<string> files = new List<string>();
            
            for(int i = 0; i < Directory.GetFiles(dialog.SelectedPath).Count(); i++)
            {
                bool found = regex.IsMatch(Directory.GetFiles(dialog.SelectedPath)[i]);
                if(found)
                {
                    files.Add(Directory.GetFiles(dialog.SelectedPath)[i]);
                }
            }
            return files.ToArray();
        }
