    class MessageWindow : Form {
      [DllImport("user32.dll")]
      static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
      
      public MessageWindow() {
         var accessHandle = this.Handle;
      }
      protected override void OnHandleCreated(EventArgs e) {
         base.OnHandleCreated(e);
         ChangeToMessageOnlyWindow();         
      }
      private void ChangeToMessageOnlyWindow() {         
         IntPtr HWND_MESSAGE = new IntPtr(-3);
         SetParent(this.Handle, HWND_MESSAGE);         
      }
      protected override void WndProc(ref Message m) {
         // respond to messages here
      } 
    }
