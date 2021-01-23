        private Point lastPos;
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            lastPos = this.Location;
        }
        protected override void OnLocationChanged(EventArgs e) {
            base.OnLocationChanged(e);
            foreach (var frm in this.OwnedForms) {
                frm.Location = new Point(frm.Location.X + this.Left - lastPos.X,
                    frm.Location.Y + this.Top - lastPos.Y);
            }
            lastPos = this.Location;
        }
        protected override void WndProc(ref Message m) {
            // Move borderless window with click-and-drag on client window
            if (m.Msg == 0x84) m.Result = (IntPtr)2;
            else base.WndProc(ref m);
        }
