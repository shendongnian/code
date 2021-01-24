    public const int WM_NCLBUTTONDOWN = 0xA1;
    public const int HT_CAPTION = 0x2;
    [DllImportAttribute("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    [DllImportAttribute("user32.dll")]
    public static extern bool ReleaseCapture();
    private void tabControl1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            var tabPage = tabControl1.SelectedTab;
            var form = new Form();
            form.Text = tabPage.Text;
            var tabControl = new TabControl();
            tabControl.TabPages.Add(tabPage);
            tabControl.Dock = DockStyle.Fill;
            form.Controls.Add(tabControl);
            form.StartPosition = FormStartPosition.Manual;
            var point = Cursor.Position;
            form.Location = new Point(point.X - form.Width / 2, 
                point.Y - SystemInformation.CaptionHeight / 2);
            form.Show();
            ReleaseCapture();
            SendMessage(form.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
    }
