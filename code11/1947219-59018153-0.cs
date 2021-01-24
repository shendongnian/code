public static void Main()
{
	try
	{
		using (Process myProcess = new Process())
		{
			myProcess.StartInfo.UseShellExecute = false;
			myProcess.StartInfo.FileName = "cmd.exe";
			myProcess.StartInfo.Arguments  = "/c Javaws -uninstall & RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 2 & echo off | clip ";
			myProcess.StartInfo.CreateNoWindow = true;
			myProcess.Start();
			// This code assumes the process you are starting will terminate itself. 
			// Given that is is started without a window so you cannot terminate it 
			// on the desktop, it must terminate itself or you can do it programmatically
			// from this application using the Kill method.
			myProcess.WaitForExit();
		}
	}
	catch (Exception e)
	{
		Console.WriteLine(e.Message);
	}
}
