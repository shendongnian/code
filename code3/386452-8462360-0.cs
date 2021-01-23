    using System.Diagnostics;
    static void printDWGFile(string f)
    {
	ProcessStartInfo startInfo = new ProcessStartInfo();
	startInfo.FileName = "print";
	startInfo.Arguments = f;
	Process.Start(startInfo);
    }
