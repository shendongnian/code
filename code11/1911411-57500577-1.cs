    [System.Runtime.InteropServices.DllImport("user32.dll")]
    extern static IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);
    const int TVM_GETNEXTITEM = 0x1100 + 10;
    const int TVGN_LASTVISIBLE = 0x000A;
    void AdjustTreeViewHeight(TreeView treeView)
    {
        treeView.Scrollable = false;
        var nodeHandle = SendMessage(treeView.Handle, TVM_GETNEXTITEM, 
            TVGN_LASTVISIBLE, IntPtr.Zero);
        var node = treeView.GetType().GetMethod("NodeFromHandle",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .Invoke(treeView, new object[] { nodeHandle }) as TreeNode;
        var r = node.Bounds;
        treeView.Height = r.Top + r.Height + 4;
    }
