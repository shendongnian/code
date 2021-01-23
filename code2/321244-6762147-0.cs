    DriveInfo[] dDrives = DriveInfo.GetDrives();
    foreach(DriveInfo dDrive in dDrives)
    {
        try
        {
            string sDrive = dDrive.ToString();
            string[] sSearch = Directory.GetFiles(sDrive, sFile, SearchOption.AllDirectories);
            foreach(string sResult in sSearch)
            {
                try
                {
                    textBox2.Text = sResult + Environment.NewLine;
                }
                catch { // Do exception handling here} 
            }
        }
        catch
        {
        }
    }
