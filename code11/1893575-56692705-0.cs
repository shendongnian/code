        private void button3_Click(object sender, EventArgs e)
        {
            string baseFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var folders = new string[]
            {
                "fivem",
                "FiveM Application Data",
                "cache",
                "browser",
                "db",
                "dunno",
                "priv",
                "servers",
                "subprocess"
            };
            foreach (var folder in folders)
            {
                var toDelete = System.IO.Path.Combine(baseFolder, folder);
                if (Directory.Exists(toDelete))
                {
                    Directory.Delete(toDelete, true);
                }
            }
        }
