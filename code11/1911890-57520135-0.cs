    private void button1_Click(object sender, EventArgs e)
        {
            Point myNewLocation = Location;
            myNewLocation.Offset(20, 20);
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open";
            MoveDialogWhenOpened(dlg.Title, myNewLocation);
            dlg.ShowDialog(this);
        }
        private void MoveDialogWhenOpened(String windowCaption, Point location)
        {
            Object[] argument = new Object[] { windowCaption, location };
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(MoveDialogThread);
            backgroundWorker.RunWorkerAsync(argument);
        }
        private void MoveDialogThread(Object sender, DoWorkEventArgs e)
        {
            const String DialogWindowClass = "#32770";
            String windowCaption = (String)(((Object[])e.Argument)[0]);
            Point location = (Point)(((Object[])e.Argument)[1]);
            // try for a maximum of 4 seconds (sleepTime * maxAttempts)
            Int32 sleepTime = 10; // milliseconds
            Int32 maxAttempts = 400;
            for (Int32 i = 0; i < maxAttempts; ++i)
            {
                // find the handle to the dialog
                IntPtr handle = Win32Api.FindWindow(DialogWindowClass, windowCaption);
                // if the handle was found and the dialog is visible
                if ((Int32)handle > 0 && Win32Api.IsWindowVisible(handle) > 0)
                {
                    // move it
                    Win32Api.SetWindowPos(handle, (IntPtr)0, location.X, location.Y,
                               0, 0, Win32Api.SWP_NOSIZE | Win32Api.SWP_NOZORDER);
                    break;
                }
                // if not found wait a brief sec and try again
                Thread.Sleep(sleepTime);
            }
        }
        public class Win32Api
        {
            public const Int32 SWP_NOSIZE = 0x1;
            public const Int32 SWP_NOZORDER = 0x4;
            [DllImport("user32")]
            public static extern IntPtr FindWindow(String lpClassName,
                                String lpWindowName);
            [DllImport("user32")]
            public static extern Int32 IsWindowVisible(IntPtr hwnd);
            [DllImport("user32")]
            public static extern Int32 SetWindowPos(IntPtr hwnd,
                                IntPtr hwndInsertAfter,
                                Int32 x,
                                Int32 y,
                                Int32 cx,
                                Int32 cy,
                                Int32 wFlags);
        }
