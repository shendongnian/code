            public string getalldrivestotalnfreespace()
        {
            string s = "    Drive          Free Space   TotalSpace     FileSystem    %Free Space       DriveType\n\r========================================================================================\n\r";
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                double ts = 0;
                double fs = 0;
                double frprcntg = 0;
                long divts = 1024 * 1024 * 1024;
                long divfs = 1024 * 1024 * 1024;
                string tsunit = "GB";
                string fsunit = "GB";
                if (drive.IsReady)
                {
                    fs = drive.TotalFreeSpace;
                    ts = drive.TotalSize;
                    frprcntg = (fs / ts) * 100;
                    if (drive.TotalSize < 1024)
                    {
                        divts =1; tsunit = "Byte(s)";
                    }
                    else if (drive.TotalSize < (1024*1024))
                    {
                        divts = 1024; tsunit = "KB";
                    }
                    else if (drive.TotalSize < (1024 * 1024*1024))
                    {
                        divts = 1024*1024; tsunit = "MB";
                    }
                    //----------------------
                    if (drive.TotalFreeSpace < 1024)
                    {
                        divfs = 1; fsunit = "Byte(s)";
                    }
                    else if (drive.TotalFreeSpace < (1024 * 1024))
                    {
                        divfs = 1024; fsunit = "KB";
                    }
                    else if (drive.TotalFreeSpace < (1024 * 1024 * 1024))
                    {
                        divfs = 1024 * 1024; fsunit = "MB";
                    }
                    s = s +
                    " " + drive.VolumeLabel.ToString() +
                    "[" + drive.Name.Substring(0, 2) +
                    "]\t" + String.Format("{0,10:0.0}", ((fs / divfs)).ToString("N2")) + fsunit +
                    String.Format("{0,10:0.0}", (ts / divts).ToString("N2")) + tsunit +
                    "\t" + drive.DriveFormat.ToString() + "\t\t" + frprcntg.ToString("N2") + "%"+
                    "\t\t" + drive.DriveType.ToString();
                    
                    s = s + "\n\r";
                }
            }
            return s;
        }
