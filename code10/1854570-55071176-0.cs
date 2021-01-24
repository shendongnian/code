    private void btnMaximize_Click(object sender, EventArgs e)
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                    btnMaximize.Image = Properties.Resources.maximize_Black;
                    Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
                }
                else
                {
                    this.WindowState = FormWindowState.Maximized;;
                    btnMaximize.Image = Properties.Resources.maximize_Black_copy;
                    Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 0, 0));
                }
            }
