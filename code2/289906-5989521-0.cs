    protected override void WndProc(ref Message m)
    {
         if (m.Msg == 256 && m.WParam.ToInt32() == 13)
         {   // WM_KEYDOWN == 256, Enter == 13
             if ((m.LParam.ToInt32() >> 24) == 0)
             {
                 MessageBox.Show("main enter pressed!");
             }
             else
             {
                 MessageBox.Show("numpad enter pressed!");
             }
          }
          else
          {
             base.WndProc(ref m);
          }
    }
