    public class NotepadHwndHost : HwndHostEx
    {
        private Process _process;
        protected override HWND BuildWindowOverride(HWND hwndParent)
        {
            ProcessStartInfo psi = new ProcessStartInfo("notepad.exe");
            _process = Process.Start(psi);
            _process.WaitForInputIdle();
            // The main window handle may be unavailable for a while, just wait for it
            while (_process.MainWindowHandle == IntPtr.Zero)
            {
                Thread.Yield();
            }
            HWND hwnd = new HWND(_process.MainWindowHandle);
            int style = NativeMethods.GetWindowLong(hwnd, GWL.STYLE);
            style = style & ~((int)WS.CAPTION) & ~((int)WS.THICKFRAME); // Removes Caption bar and the sizing border
            style |= ((int)WS.CHILD); // Must be a child window to be hosted
            NativeMethods.SetWindowLong(hwnd, GWL.STYLE, style);
            return hwnd;
        }
        protected override void DestroyWindowOverride(HWND hwnd)
        {
            _process.CloseMainWindow();
            _process.WaitForExit(5000);
            if (_process.HasExited == false)
            {
                _process.Kill();
            }
            _process.Close();
            _process.Dispose();
            _process = null;
            hwnd.Dispose();
            hwnd = null;
        }
    }
