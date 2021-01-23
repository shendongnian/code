	[STAThread]
	public static int Main(string[] args)
	{
		try
		{
			AttachConsole(ATTACH_PARENT_PROCESS);
			...
			...
		}
		catch (Exception eCatchAll)
		{
			ShowHelpCommand.ShowHelp(eCatchAll.ToString());		
			return (int) ConsoleReturnCode.UnexpectedError;
		}
		finally
		{
			ConsoleNewLine();
		}
	}
	private static void ConsoleNewLine()
	{
		try
		{
			// When using a winforms app with AttachConsole the app complets but there is no newline after the process stops. This gives the newline and looks normal from the console:
			SendKeys.SendWait("{ENTER}");
		}
		catch (Exception e)
		{
			Debug.Fail(e.ToString());
		}
	}
