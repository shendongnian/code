        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var bg = new Form();
            bg.WindowState = FormWindowState.Maximized;
            bg.ShowInTaskbar = false;
            bg.FormBorderStyle = FormBorderStyle.None;
            bg.Show();
            bg.Enabled = false;
            this.Owner = bg; // optional - see below
        }
