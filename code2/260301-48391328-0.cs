    public class ListBoxEx : ListBox {
      private const int WM_LBUTTONDOWN = 0x201;
    
      protected override void WndProc(ref Message m) {
        int lParam = m.LParam.ToInt32();
        int wParam = m.WParam.ToInt32();
        if (m.Msg == WM_LBUTTONDOWN) {
          Point clickedPt = new Point();
          clickedPt.X = lParam & 0x0000FFFF;
          clickedPt.Y = lParam >> 16;
          bool lineOK = false;
          for (int i = 0; i < Items.Count; i++) {
            if (GetItemRectangle(i).Contains(clickedPt)) {
              lineOK = true;
            }
          }
          if (!lineOK) {
            return;
          }        
        }
        base.WndProc(ref m);
      }
    }
