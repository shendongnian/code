            string[] folders = Directory.GetDirectories(textBox1.Text, "*.*", SearchOption.TopDirectoryOnly);
            long d = 0;
            long c = 0;
            //And iterate through it, moving to the defined directory 
            while (d <= k)
            {
                while (i <= h)
                {
                    try
                    {
                        string folder = folders[d];
                        string file = files[c];
                        File.Move(file, folder + @"\" + Path.GetFileName(file));
                        c++;
                        i++;
                        lblFilesMoved.Text = "Files Moved: " + i;
                    }
                    catch (Exception f)
                    {
                        MessageBox.Show(f.ToString());
                    }
                }
                d++;
                i = 0;
