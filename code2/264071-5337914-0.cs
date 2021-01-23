    public class CustomComboBox : ComboBox
    {
      protected override void WndProc( ref  Message m )
      {
        if(yourCondition && 
           (m.Msg == 0x201 || // WM_LBUTTONDOWN
            m.Msg == 0x203)) // WM_LBUTTONDBLCLK
          return;
        base.WndProc( ref m );
      }
    }
