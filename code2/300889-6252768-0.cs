    foreach (String drives in Environment.GetLogicalDrives())
    {
        if(!Enum.GetName(typeof(DriveType), GetDriveType(s))
            .Equals(DriveType.Removable))
        {
            continue;
        }
        MessageBox.Show(drives);
    }
