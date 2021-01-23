        //This is my docking window
        private System.Diagnostics.Process notepad;
        private void windowDockTest()
        {
            /*
             * Docking notepad to panel2 of the splitcontainer
             */
 
            //if panel2 moves or is resized, call the docking function
            spcScript.Panel2.Move += new EventHandler(Panel2_Resize);
            spcScript.Panel2.SizeChanged += new EventHandler(Panel2_Resize);
            
            //Call the docking function if main form is moved
            this.LocationChanged += new EventHandler(Panel2_Resize);
            //Start the notepad process
            notepad = new System.Diagnostics.Process();
            notepad.StartInfo.FileName = "notepad";
            notepad.Start();
            //Wait a second for notpad to fully load
            notepad.WaitForInputIdle(1000);
            //Dock it
            Panel2_Resize(new Object(), new EventArgs());
        }
        void Panel2_Resize(object sender, EventArgs e)
        {
            //Get the screen location of panel2
            Rectangle r = spcScript.Panel2.RectangleToScreen(spcScript.Panel2.ClientRectangle);
            //Dock it
            redock(notepad.MainWindowHandle, r.X, r.Y, r.Width, r.Height);
        }
        
        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);
        public static void redock(IntPtr handle, int x, int y, int width, int height)
        {
            IntPtr HWND_TOPMOST = new IntPtr(-1);
            const short SWP_NOACTIVATE = 0x0010;
            SetWindowPos(handle,HWND_TOPMOST, x, y, width, height,SWP_NOACTIVATE);
        }
