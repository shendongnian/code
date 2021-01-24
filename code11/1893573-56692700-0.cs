    private void button3_Click(object sender, EventArgs e)
            {
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string path = System.IO.Path.Combine(folder, "fivem");
                string fap = System.IO.Path.Combine(path, "FiveM Application Data");
                string cache = System.IO.Path.Combine(path, "cache");
                string browser = System.IO.Path.Combine(path, "browser");
                string db = System.IO.Path.Combine(path, "db");
                string dunno = System.IO.Path.Combine(path, "dunno");
                string priv = System.IO.Path.Combine(path, "priv");
                string servers = System.IO.Path.Combine(path, "servers");
                string subprocess = System.IO.Path.Combine(path, "subprocess");
            if (Directory.Exists(fap))
            {
                Directory.Delete(fap);
            }
            if (Directory.Exists(cache))
            {
                Directory.Delete(cache);
            }
            //repeat for all the variables
            if (Directory.Exists(subprocess))
            {
                Directory.Delete(subprocess);
            }
        }
