        private void button3_Click(object sender, EventArgs e)
        {
            string baseFolder = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"fivem", "FiveM.app");
            foreach (var subDir in new DirectoryInfo(baseFolder).GetDirectories()) {
                subDir.Delete(true);
            }
        }
