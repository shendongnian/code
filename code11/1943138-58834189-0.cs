	while (true)
	{
		Process[] pdfProcess = Process.GetProcessesByName("pdfsave");
		if (pdfProcess.Length == 0)
		{
			break;
		}
		Thread.Sleep(50);
	}
	if (File.Exists(strIniPath + "pdf995.ini"))
	{
		File.Delete(strIniPath + "pdf995.ini");
	}
	File.Move(strIniPath + "pdf995.ini_backup", strIniPath + "pdf995.ini");
