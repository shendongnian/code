            using System.Management;
            .........
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            disk.Get();
            MessageBox.Show(disk["FreeSpace"] + " bytes");
