    private void concept()
            {
                string fullpath = Path.GetTempPath();
                string[] ph = fullpath.Split('\\');
                bool fix = false;
                string fixedpath = "";
                foreach (string word in ph)
                {
    
                    if (fix == false)
                    {
                        fixedpath = fixedpath + word + @"\";
                    }
                    if (word == "Temp")
                    {
                        fix = true;
                    }
    
                }
                MessageBox.Show(fixedpath);
            }
