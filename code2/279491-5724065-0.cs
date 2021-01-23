    [DllImport("user32.dll")]
    internal static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
    internal const int WM_SETFONT = 0x0030;
    internal const int TVM_GETEDITCONTROL = 0x110F;
    private void treeView1_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
    {
        TreeNode nodeEditing = e.Node;
        IntPtr editControlHandle = (IntPtr)SendMessage(treeView1.Handle, (uint)TVM_GETEDITCONTROL, 0, 0);
        if (editControlHandle != IntPtr.Zero)
        {
            SendMessage(editControlHandle, (uint)WM_SETFONT, (int)nodeEditing.NodeFont.ToHfont(), 1);
        }
    }
