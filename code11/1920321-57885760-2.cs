    [Serializable]
    [CompilerGenerated]
    private sealed class <>c
    {
        public static readonly <>c <>9 = new <>c();
        public static GetMsgProc <>9__7_0;
        internal void <InstallHook>b__7_0(int code, IntPtr wParam, IntPtr lParam)
        {
            object[] obj = new object[6];
            obj[0] = "SetWindowsHookEx; code: ";
            obj[1] = code;
            obj[2] = ", wParam: ";
            obj[3] = wParam.ToString();
            obj[4] = ", lParam: ";
            obj[5] = lParam.ToString();
            Debug.WriteLine(string.Concat(obj));
        }
    }
    public static void InstallHook(int i)
    {
        Debug.WriteLine("Installing: " + i);
        GetMsgProc hookProc = <>c.<>9__7_0 ?? (<>c.<>9__7_0 = new GetMsgProc(<>c.<>9.<InstallHook>b__7_0));
        IntPtr intPtr = SetWindowsHookEx(i, hookProc, _handle, 0u);
    }
