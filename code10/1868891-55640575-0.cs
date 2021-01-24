        private PictureBox CreateErrorControl2(string name) //, Control control)
        {
            var errorIcon = new PictureBox();
            errorIcon.Name = name;
            errorIcon.Size = new Size(32, 32);
            errorIcon.Cursor = Cursors.Default;
            errorIcon.BackColor = Color.Transparent;
            errorIcon.Visible = false;
            errorIcon.MouseMove += new MouseEventHandler(DisplayToolTip);
            return errorIcon;
        }
