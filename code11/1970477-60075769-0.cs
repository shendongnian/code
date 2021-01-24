    //// compile with:   
    // /r:Microsoft.SqlServer.Smo.dll  
    // /r:Microsoft.SqlServer.SmoExtended.dll 
    // /r:Microsoft.SqlServer.ConnectionInfo.dll  
    
    using System;
    using System.Data;
    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.SqlServer.Management.Common;
    
    namespace SMObackup
    {
        class Program
        {
            static void Main()
            {
    
                // For remote connection, remote server name / ServerInstance needs to be specified  
                ServerConnection srvConn2 = new ServerConnection("machinename"/* <--default sql instance on machinename*/);  // or (@"machinename\sqlinstance") for named instances
                srvConn2.LoginSecure = false;
                srvConn2.Login = "smologin";
                srvConn2.Password = "SmoL@gin11";
                srvConn2.DatabaseName = "msdb";
                Server srv3 = new Server(srvConn2);
    
                //server info
                Console.WriteLine("servername:{0} ---- version:{1}", srv3.Name, srv3.Information.Version);
    
                //server root directory
                string serverRootDir = srv3.Information.RootDirectory;
                //server backup directory
                string serverBackupDir = srv3.Settings.BackupDirectory;
                //database primary directory
                string databasePrimaryFilepath = srv3.Databases[srvConn2.DatabaseName].PrimaryFilePath;
                
                Console.WriteLine("server_root_dir:{0}\nserver_backup_dir:{1}\ndatabase_primary_dir{2}", serverRootDir, serverBackupDir, databasePrimaryFilepath);
    
                Backup bkpDbFull = new Backup();
                bkpDbFull.Action = BackupActionType.Database;
                //comment out copyonly ....
                bkpDbFull.CopyOnly = true; //copy only, just for testing....avoid messing up with existing backup processes
                bkpDbFull.Database = srvConn2.DatabaseName;
    
                //backup file name
                string backupfile = $"\\backuptest_{DateTime.Now.ToString("dd/MM/yyyy/hh/mm/ss")}.bak";
    
                //add multiple files, in each location
                bkpDbFull.Devices.AddDevice(serverRootDir + backupfile, DeviceType.File);
                bkpDbFull.Devices.AddDevice(serverBackupDir + backupfile, DeviceType.File);
                bkpDbFull.Devices.AddDevice(databasePrimaryFilepath + backupfile, DeviceType.File);
                bkpDbFull.Initialize = true;
    
                foreach (BackupDeviceItem backupdevice in bkpDbFull.Devices)
                {
                    Console.WriteLine("deviceitem:{0}", backupdevice.Name);
                }
    
                //backup is split/divided amongst the 3 devices
                bkpDbFull.SqlBackup(srv3);
    
                Restore restore = new Restore();
                restore.Devices.AddRange(bkpDbFull.Devices);
                DataTable backupHeader = restore.ReadBackupHeader(srv3);
    
    
                //IsCopyOnly=True
                for (int r = 0; r < backupHeader.Rows.Count; r++)
                {
                    for (int c = 0; c < backupHeader.Columns.Count; c++)
                    {
                        Console.Write("{0}={1}\n", backupHeader.Columns[c].ColumnName, (string.IsNullOrEmpty(backupHeader.Rows[r].ItemArray[c].ToString())? "**": backupHeader.Rows[r].ItemArray[c].ToString()) );
                    }
                }
    
                srvConn2.Disconnect(); //redundant
    
            }
        }
    }
