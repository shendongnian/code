        protected override void OnLoad(EventArgs e) {
            var scr = Screen.FromPoint(this.Location);
            this.Left = scr.WorkingArea.Left + (scr.WorkingArea.Width - this.Width) / 2;
            this.Top = scr.WorkingArea.Top + (scr.WorkingArea.Height - this.Height) / 2;
            base.OnLoad(e);
        }
