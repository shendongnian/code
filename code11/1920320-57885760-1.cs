    [CompilerGenerated]
    private sealed class <>c__DisplayClass7_0
    {
        public int i;
        internal void <InstallHook>b__0(int code, IntPtr wParam, IntPtr lParam)
        {
            object[] obj = new object[8];
            obj[0] = "SetWindowsHookEx; i: ";
            obj[1] = i;
            obj[2] = ", code: ";
            obj[3] = code;
            obj[4] = ", wParam: ";
            obj[5] = wParam.ToString();
            obj[6] = ", lParam: ";
            obj[7] = lParam.ToString();
            Debug.WriteLine(string.Concat(obj));
        }
    }
    public static void InstallHook(int i)
    {
        <>c__DisplayClass7_0 <>c__DisplayClass7_ = new <>c__DisplayClass7_0();
        <>c__DisplayClass7_.i = i;
        Debug.WriteLine("Installing: " + <>c__DisplayClass7_.i);
        GetMsgProc hookProc = new GetMsgProc(<>c__DisplayClass7_.<InstallHook>b__0);
        IntPtr intPtr = SetWindowsHookEx(<>c__DisplayClass7_.i, hookProc, _handle, 0u);
    }
