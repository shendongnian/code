    protected override void WndProc(ref Message m)
    {
        switch (m.Msg)
        {
          case 0x84: m.Result = new IntPtr(0x2);
              return;
        }
        base.WndProc(ref m);
    }
