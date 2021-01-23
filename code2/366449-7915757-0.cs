     namespace Controls
     {
      public partial class BaseForm : Form
      {
        public BaseForm()
        {
          InitializeComponent();
          StartPosition = FormStartPosition.WindowsDefaultLocation;
          MaximizeBox = false;
          Width = 806;
          //Width = 850;
          //Height = 760;
          Height = 730;
          //Width = 790;
          //Height = 617;
        }
    
     
        protected override void WndProc(ref Message m)
        {
          const int WM_SYSCOMMAND = 0x0112;
          const int SC_MOVE = 0xF010;
          //ShowScrollBar(this.Handle, (int)ScrollBarDirection.SB_BOTH, false);
          switch (m.Msg)
          {
            case WM_SYSCOMMAND:
              int command = m.WParam.ToInt32() & 0xfff0;
              if (command == SC_MOVE)
                return;
              break;
          }
          base.WndProc(ref m);
        }
      }
    }
