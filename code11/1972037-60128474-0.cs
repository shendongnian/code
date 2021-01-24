    private void Form1_Load(object sender, EventArgs e)
            {
                StartPosition = FormStartPosition.Manual;
                Location = new Point(0, 0);
                var height = Screen.AllScreens.Max(x => x.WorkingArea.Height + x.WorkingArea.Y);
                var width = Screen.AllScreens.Max(x => x.WorkingArea.Width + x.WorkingArea.X);
                Size = new Size(width, height);
            }
