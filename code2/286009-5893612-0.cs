    if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string file in files)
                {
                    if (Directory.Exists(file))
                    {
                        string[] filenames = Directory.GetFiles(file);
                        foreach (string filename in filenames)
                        {
                            GetFiles(filename);
                        }
                    }
                    GetFiles(file);
                }
            }
        
        private void GetFiles(string file)
        {
            FileInfo fi = new FileInfo(file);
            listView1.Items.Add(fi.Name);
            listView1.Items[listView1.Items.Count - 1].SubItems.Add("test");
        }
