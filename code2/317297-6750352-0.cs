    protected override void OnKeyDown(KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Tab) {
            WinApi.SendMessage(Handle, WinApi.WmChar, WinApi.VkSpace, (IntPtr)4);
            e.SuppressKeyPress = true;
        }
        base.OnKeyDown(e);
    }
