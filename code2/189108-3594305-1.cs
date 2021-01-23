        private void button1_Click(object sender, EventArgs e) {
            if (this.MdiParent != null) {
                MdiClient client = null;
                foreach (Control ctl in this.MdiParent.Controls) {
                    if (ctl is MdiClient) { client = ctl as MdiClient; break; }
                }
                this.WindowState = FormWindowState.Normal;
                Point loc = client.PointToScreen(this.Location);
                this.MdiParent = null;
                this.Location = loc;
            }
        }
