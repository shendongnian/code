    private const int WH_KEYBOARD_LL = 20;
    private static int _hookHandle;
    private HookProc _hookDelegate;
    [DllImport("coredll.dll")]
    private static extern int SetWindowsHookEx(int type, HookProc hookProc, IntPtr       hInstance, int m);
    [DllImport("coredll.dll")]
    private static extern IntPtr GetModuleHandle(string mod);
    [DllImport("coredll.dll", SetLastError = true)]
    private static extern int UnhookWindowsHookEx(int idHook);
    [DllImport("coredll.dll")]
    private static extern int CallNextHookEx(HookProc hhk, int nCode, IntPtr wParam, IntPtr lParam);
    private bool HookKeyboardEvent(bool action)
    {
	try
	{
		if (action)
		{
			HookKeyboardEvent(false);
			_hookDelegate = new HookProc(HookProcedure);
			_hookHandle = SetWindowsHookEx(WH_KEYBOARD_LL, _hookDelegate, GetModuleHandle(null), 0);
			if (_hookHandle == 0)
			{
				return false;
			}
			return true;
		}
		if (_hookHandle != 0)
		{
			//Unhook the previouse one
			UnhookWindowsHookEx(_hookHandle);
			return true;
		}
		return false;
	}
	catch (Exception ex)
	{
		string dump = ex.Message;
		return false;
	}
    }
    private int HookProcedure(int code, IntPtr wParam, IntPtr lParam)
    {
	try
	{
		var hookStruct = (KBDLLHOOKSTRUCT) Marshal.PtrToStructure(lParam, typeof (KBDLLHOOKSTRUCT));
		if (DoHardwareKeyPress(hookStruct.vkCode, hookStruct.scanCode, wParam.ToInt32()))
			return CallNextHookEx(_hookDelegate, code, wParam, lParam);
		else
			return -1;
	}
	catch (Exception ex)
	{
		string dump = ex.Message;
		return -1;
	}
    }
    private bool DoHardwareKeyPress(int softKey, int hardKey, int keyState)
    {
	try
	{
		string keyPressInformation = string.Format("SoftKey = {0}, HardKey = {1}, KeyState = {2}", softKey, hardKey,
		                                           keyState);
		if (softKey == 114 && hardKey == 4 && (keyState == 256 || keyState == 257))
			return false;
		else if (softKey == 115 && hardKey == 12 && (keyState == 256 || keyState == 257))
			return false;
		else
			return true;
	}
	catch (Exception ex)
	{
		string dump = ex.Message;
		return true;
	}
    }
    #region Nested type: HookProc
    internal delegate int HookProc(int code, IntPtr wParam, IntPtr lParam);
    #endregion
    #region Nested type: KBDLLHOOKSTRUCT
    private struct KBDLLHOOKSTRUCT
    {
	public IntPtr dwExtraInfo;
	public int flags;
	public int scanCode;
	public int time;
	public int vkCode;
    }
    #endregion
