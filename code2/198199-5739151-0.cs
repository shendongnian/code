            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowserDialog.SelectedPath;
                fileSystemWatcher.Path = path;
                string[] str = Directory.GetFiles(path);
                string line;
                fs = new FileStream(str[0], FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                tr = new StreamReader(fs); 
                
                while ((line = tr.ReadLine()) != null)
                {
                    listBox.Items.Add(line);
                }
                
            }
        }
        private void fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            string line;
            line = tr.ReadLine();
            listBox.Items.Add(line);  
        }
