    System.Runtime.InteropServices
    
    private const int SWP_NOSIZE = 0x1;
    private const int WM_CTLCOLORLISTBOX = 0x0134;
    
    [DllImport("user32.dll")]
    static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int
    X, int Y, int cx, int cy, uint uFlags);
    protected override void WndProc(ref Message m)
    {
         if (m.Msg == WM_CTLCOLORLISTBOX)
         {
             // Make sure we are inbounds of the screen
             int left = this.PointToScreen(new Point(0, 0)).X;
    
             //Only do this if the dropdown is going off right edge of screen
             if (this.DropDownWidth > Screen.PrimaryScreen.WorkingArea.Width - left)
             {
                // Get the current combo position and size
                Rectangle comboRect = this.RectangleToScreen(this.ClientRectangle);
                int dropHeight = 0;
                int topOfDropDown = 0;
                int leftOfDropDown = 0;
                //Calculate dropped list height
                for (int i = 0; (i < this.Items.Count && i < this.MaxDropDownItems); i++)
                {
                    dropHeight += this.ItemHeight;
                }
                //Set top position of the dropped list if 
                //it goes off the bottom of the screen
                if (dropHeight > Screen.PrimaryScreen.WorkingArea.Height -
                       this.PointToScreen(new Point(0, 0)).Y)
                {
                    topOfDropDown = comboRect.Top - dropHeight - 2;
                }
                else
                {
                    topOfDropDown = comboRect.Bottom;
                }
                //Calculate shifted left position
                leftOfDropDown = comboRect.Left - (this.DropDownWidth -
                       (Screen.PrimaryScreen.WorkingArea.Width - left));
                //when using the SWP_NOSIZE flag, cx and cy params are ignored
                SetWindowPos(m.LParam,
                             IntPtr.Zero,
                             leftOfDropDown,
                             topOfDropDown,
                             0,
                             0,
                             SWP_NOSIZE);
              }
          }
          base.WndProc(ref m);
    }
