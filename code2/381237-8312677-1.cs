    private void CopyAvailableCheck()
    {
        var listOfDisks = FreeDriveSpace();
        foreach( var disk in listOfDisks )
        {
            if ( disk.Status == 1)
            {
             // do something
            }
            else if ( disk.Status = 0 )
            {
              //do something else
            }
        }
    }
    public static List<Disk> FreeDriveSpace()
    {
        DriveInfo[] allDrives = DriveInfo.GetDrives();
        var listOfDisks = new List<Disk>();
        foreach (DriveInfo d in allDrives)
        {
            var currentDisk = new Disk( d.Name );   
            if (d.IsReady == true)
            {
                // If total free space is more than 30 GB (default)
                if (d.TotalFreeSpace >= 32212254720) // default: 32212254720
                {
                    currentDisk.Status = 1;
                }
                else
                {
                    currentDisk.Status = 0; // Not enough space
                }
            }
            listOfDisks.Add( currentDisk );
        }
        return listOfDisks;  
    }
    public class Disk
    {
        public Disk( string name )
        {
            Name = name;
        }
  
        public string Name
        {
            get; set;
        }
        public int Status
        {
            get; set;
        }
    }
