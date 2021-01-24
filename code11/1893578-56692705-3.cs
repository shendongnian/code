        private void button3_Click(object sender, EventArgs e)
        {
            string baseFolder = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"fivem", "FiveM.app");
            var folders = new string[]
            {
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
