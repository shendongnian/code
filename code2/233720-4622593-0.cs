        public static void ShowFullScreen(Control ctl) {
            // Setup host form to be full screen
            var host = new Form();
            host.FormBorderStyle = FormBorderStyle.None;
            host.WindowState = FormWindowState.Maximized;
            host.ShowInTaskbar = false;
            // Save properties of control
            var loc = ctl.Location;
            var dock = ctl.Dock;
            var parent = ctl.Parent;
            var form = parent;
            while (!(form is Form)) form = form.Parent;
            // Move control to host
            ctl.Parent = host;
            ctl.Location = Point.Empty;
            ctl.Dock = DockStyle.Fill;
            // Setup event handler to restore control back to form
            host.FormClosing += delegate {
                ctl.Parent = parent;
                ctl.Dock = dock;
                ctl.Location = loc;
                form.Show();
            };
            // Exit full screen with escape key
            host.KeyPreview = true;
            host.KeyDown += (KeyEventHandler)((s, e) => {
                if (e.KeyCode == Keys.Escape) host.Close();
            });
            // And go full screen
            host.Show();
            form.Hide();
        }
