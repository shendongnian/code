                frm = new Form2();
                frm.Show();
            }
    // Minimize issue is handled
        private void Form1_Resize(object sender, EventArgs e)
                {
                    if (this.WindowState == FormWindowState.Minimized)
                    {
                        frm.WindowState = this.WindowState;
                    }
                }
