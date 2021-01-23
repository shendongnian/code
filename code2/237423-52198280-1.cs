    string command = "systeminfo /fo LIST | Select-String \"System Type\", \"OS Name\", \"OS Version\"";
    List<PSObject> resultOS = InvokePowershell(command, remoteMachineName);
    string nameOS = resultOS.Find(obj => obj.ToString().Contains("OS Name")).ToString().Split(':').Last().Trim();
    string versionOS = resultOS.Find(obj => obj.ToString().ContainsString("OS Version")).ToString().Split(null).Last().Trim();
    string architectureOS = resultOS.Find(obj => obj.ToString().ContainsString("System Type")).ToString().Split(':').Last().Trim();
