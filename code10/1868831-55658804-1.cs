    string unc = "https://webdav.xxx.de/";
    string drive = "Q:";
    string username = "someUser";
    string password = "somePassword";
    
    int status =
      Utilities.Network.NetworkDrive.MapNetworkDrive(unc, drive, username, password);
    if (status == 0)
    {
         Console.WriteLine($"{unc} mapped to drive {drive}");
    }
    else
    {
         //  https://stackoverflow.com/a/1650868/1911064
         string errorMessage = 
             new System.ComponentModel.Win32Exception(status).Message;
         Console.WriteLine($"Failed to map {unc} to drive {drive}!");
         Console.WriteLine(errorMessage);
    }
