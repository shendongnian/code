cs
public static class Program
{
	private const int WH_KEYBOARD_LL = 13;
	private static IntPtr hookId = IntPtr.Zero;
	private static HookProc proc;
	public static void Begin()
	{
		hookId = SetHook();
		proc = HookCallback;
		GC.KeepAlive(proc);
		Application.Run();
		UnhookWindowsHookEx(hookId);
	}
     … etc
