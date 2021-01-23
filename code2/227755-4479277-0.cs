        public static Form ShowImage(Image image) {
            Form frm = new Form();
            frm.ControlBox = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.BackgroundImage = image;
            frm.BackgroundImageLayout = ImageLayout.Zoom;
            Screen scr = Screen.AllScreens.Length > 1 ? Screen.AllScreens[1] : Screen.PrimaryScreen;
            frm.Location = new Point(scr.Bounds.Left, scr.Bounds.Top);
            frm.Size = scr.Bounds.Size;
            frm.BackColor = Color.Black;
            frm.Show();
            return frm;
        }
