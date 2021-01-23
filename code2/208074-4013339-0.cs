    protected override void WndProc(ref Message m)
    {
        switch (m.Msg)
        {
          0x84: m.Result = 0x2;
              return;
        }
        base.WndProc(ref m);
    }
