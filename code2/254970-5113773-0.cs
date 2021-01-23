    protected override void WinProc(ref Message m)
    {
       if (m.Msg == WM_PASTE || m.Msg == WM_COPY || m.Msg == WM_CUT)
       {
          // ignore input if it was from a keyboard shortcut
          // or a Menu command
       }
       else
       {
          // handle the windows message normally
          base.WinProc(ref m);
       }
    }
