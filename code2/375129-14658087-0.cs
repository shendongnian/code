    string[] dirs = System.IO.Directory.GetDirectories(Directory.GetCurrentDirectory(), "*.*",SearchOption.AllDirectories);
                foreach (string d in dirs)
                {
                    if (System.IO.Directory.Exists(d)) {
                        if (System.IO.Directory.GetFiles(d, "*.*", SearchOption.AllDirectories).Length == 0)
                        {
                            DeleteDirectory(d);
                        }
                    }
                }
			
        public static void DeleteDirectory(string target_dir)
        {
            string[] dirs = Directory.GetDirectories(target_dir);
            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }
            Directory.Delete(target_dir, false);
        }
