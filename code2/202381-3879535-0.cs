            List<string> allFolders = new List<string>();
            allFolders.Add(@"C:\joomla\");
            foreach (string folder in allFolders)
            {
                string[] subFolders = Directory.GetDirectories(folder, "*", SearchOption.AllDirectories);
                MessageBox.Show("Test");
            }
