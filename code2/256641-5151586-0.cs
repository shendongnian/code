        DriveInfo[] drive = DriveInfo.GetDrives();
        for (long count = 0; count < drive.LongLength; count++)
        {
            string[] dir = Directory.GetDirectories(drive.GetValue(count).ToString(), "*", SearchOption.AllDirectories);
            for (long dr = 0; dr < dir.LongLength; dr++)
            {
                string[] file = Directory.GetFiles(dir.GetValue(dr).ToString(), "*", SearchOption.AllDirectories);
                for (long fl = 0; fl < file.LongLength; fl++)
                {
                    wr.WriteLine(file.GetValue(fl));
                }
            }
        }
    }
