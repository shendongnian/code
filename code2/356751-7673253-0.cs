    private const int WM_VSCROLL = 0x115;
    [DllImport("user32.dll")]
    static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, UIntPtr wParam, IntPtr lParam);
    private void listBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Down)
        {
            SendMessage(this.listBox.Handle, (uint)WM_VSCROLL, (System.UIntPtr)ScrollEventType.SmallIncrement, (System.IntPtr)0);
            e.Handled = true;
        }
        if (e.KeyCode == Keys.Up)
        {
            SendMessage(this.listBox.Handle, (uint)WM_VSCROLL, (System.UIntPtr)ScrollEventType.SmallDecrement, (System.IntPtr)0);
            e.Handled = true;
        }
    }
