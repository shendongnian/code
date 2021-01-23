    private void Form1_Shown(object sender, EventArgs e)
    {
        // Show here tray icon
        ....
        ....
        // Hide form
        this.Hide();
    }
    int WM_MYMSG = WM_USER + 1;
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_MYMSG) Close();
        base.WndProc(ref m);
    }
