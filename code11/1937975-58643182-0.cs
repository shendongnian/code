    private void changePath()
        {
            String path = webBrowser1.Url.AbsolutePath;
            if (path.Contains(@"/")) { path = path.Replace(@"/", @"\"); }
            string[] directories = path.Split(Path.DirectorySeparatorChar);
            int count = directories.Count();
            if (count <= 6)
            {
                textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = ""; textBox6.Text = "";
                for (int i = 0; i < count; i++)
                {
                    String txt = "textBox" + (i + 1);
                    TextBox tbx = this.Controls.Find(txt, true).FirstOrDefault() as TextBox;
                    tbx.Text = directories[i];
                }
            }
            else
            {
                int p = count / 6;
                int z = count - (p * 6);
                for (int i = 0; i < count; i++)
                {
                    int g = i - 1;
                    String txt = "textBox" + (i + 1);
                    TextBox tbx = this.Controls.Find(txt, true).FirstOrDefault() as TextBox;
                    tbx.Text = directories[z];
                    z++;
                    if (i == 5)
                    {
                        break;
                    }
                }
            }
        }
