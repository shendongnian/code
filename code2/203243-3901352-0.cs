        private void timer1_Tick(object sender, EventArgs e) {
            var hdl = WindowFromPoint(Control.MousePosition);
            var ctl = Control.FromHandle(hdl);
            if (ctl != null) {
                var rel = ctl.PointToClient(Control.MousePosition);
                if (ctl.ClientRectangle.Contains(rel)) {
                    Console.WriteLine("Found {0}", ctl.Name);
                    return;
                }
            }
            Console.WriteLine("No match");
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(Point loc);
