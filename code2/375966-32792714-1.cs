    internal class NativeMethodsWraper : INativeMethods
    {       
        public IntPtr SendMessage(IntPtr hwnd, uint msg, IntPtr wparam, StringBuilder lparam)
        {
            return NativeMethods.SendMessage(hwnd, msg, wparam, lparam);
        }
        public bool GetWindowRect(IntPtr hwnd, out Rect rect)
        {
            return NativeMethods.GetWindowRect(hwnd, out rect);
        }
        public IntPtr GetWindow(IntPtr hwnd, uint cmd)
        {
            return NativeMethods.GetWindow(hwnd, cmd);
        }
        public bool IsWindowVisible(IntPtr hwnd)
        {
            return NativeMethods.IsWindowVisible(hwnd);
        }
        public long GetTickCount64()
        {
            return NativeMethods.GetTickCount64();
        }
        public int GetClassName(IntPtr hwnd, StringBuilder classNameBuffer, int maxCount)
        {
            return NativeMethods.GetClassName(hwnd, classNameBuffer, maxCount);
        }
        public int DwmGetWindowAttribute(IntPtr hwnd, int attribute, out Rect rect, int sizeOfRect)
        {
            return NativeMethods.DwmGetWindowAttribute(hwnd, attribute, out rect, sizeOfRect);
        }
        public bool GetWindowPlacement(IntPtr hwnd, ref WindowPlacement pointerToWindowPlacement)
        {
            return NativeMethods.GetWindowPlacement(hwnd, ref pointerToWindowPlacement);
        }
        public int GetDeviceCaps(IntPtr hdc, int index)
        {
            return NativeMethods.GetDeviceCaps(hdc, index);
        }
    }
