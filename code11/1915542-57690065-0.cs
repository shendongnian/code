    [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
    public static extern short GetKeyState(int keyCode);
    public const int KEY_PRESSED = 0x8000;
    public static bool IsKeyDown(Keys key)
    {
        return Convert.ToBoolean(GetKeyState((int)key) & KEY_PRESSED);
    }
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        Application.Idle += Application_Idle;
    }
    void Application_Idle(object sender, EventArgs e)
    {
        if (!contextMenuStrip1.Visible)
            return;
        if (IsKeyDown(Keys.ShiftKey))
            someMenuItem.Text = "Shift is Down";
        else
            someMenuItem.Text = "Shift is Up";
    }
    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        Application.Idle -= Application_Idle;
        base.OnFormClosed(e);
    }
