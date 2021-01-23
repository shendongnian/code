    public class ListBoxEx : ListBox {
      public event EventHandler Scrolling;
      private const int WM_VSCROLL = 0x0115;
      private void OnScrolling() {
        if (Scrolling != null)
          Scrolling(this, new EventArgs());
      }
      protected override void WndProc(ref Message m) {
        base.WndProc(ref m);
        if (m.Msg == WM_VSCROLL)
          OnScrolling();
      }
    }
