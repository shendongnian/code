           public List<string> images = new List<string>();
            protected string realPath;
            protected void Page_Load(object sender, EventArgs e)
            {
                string path = Server.MapPath(@"~\upload\Gallery"); 
                // this gets the actual directory path.
                realPath = Path.Combine(path, Config.VirtualDir + "upload/Gallery/");
                //this changes the path to the VirtualDir path
                DirectoryInfo di = new DirectoryInfo(path);
                //this gets file names in the folder
                foreach(var fi in di.GetFiles())
                {
                    images.Add(fi.Name);
                    //adds file names to images list
                }
            }
