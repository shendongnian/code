    protected override void WndProc(ref Message m)
    {
      // Filter WM_LBUTTONDBLCLK when we're showing check boxes
      if (m.Msg == 0x203 && CheckBoxes)
      {
        // See if we're over the checkbox. If so then we'll handle the toggling of it ourselves.
        int x = m.LParam.ToInt32() & 0xffff;
        int y = (m.LParam.ToInt32() >> 16) & 0xffff;
        TreeViewHitTestInfo hitTestInfo = HitTest(x, y);
        if (hitTestInfo.Node != null && hitTestInfo.Location == TreeViewHitTestLocations.StateImage)
        {
          OnBeforeCheck(new TreeViewCancelEventArgs(hitTestInfo.Node, false, TreeViewAction.ByMouse));
          hitTestInfo.Node.Checked = !hitTestInfo.Node.Checked;
          OnAfterCheck(new TreeViewEventArgs(hitTestInfo.Node, TreeViewAction.ByMouse));
          m.Result = IntPtr.Zero;
          return;
        }
      }
      base.WndProc(ref m);
    }
