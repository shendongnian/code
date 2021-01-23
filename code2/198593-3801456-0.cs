    public bool RestoreDB(string dbName, string backupPath, string newLocation,string userName,sring Password)
            {            
    			ServerConnection con = new ServerConnection(serverName);
    			if(userName=="")
    				con.LoginSecure = true;
    			else{
    				con.LoginSecure = false;
    				con.Login = userName;
    				con.Password = Password;         
    			}
    			Restore restoreObj = new Restore();			
                var srv = new Server(con);
                if (srv != null)
                {
                    restoreObj.Action = RestoreActionType.Database;
                    restoreObj.Database = dbName;
                    BackupDeviceItem resDevice = new BackupDeviceItem(backupPath, DeviceType.File);
                    restoreObj.PercentCompleteNotification = 10;
                    restoreObj.ReplaceDatabase = false;                
                    restoreObj.Devices.Add(resDevice);                 
                   
                    restoreObj.PercentComplete += (sender, evtargs) =>
                    {
                       //on progress callback
                    };
    
                    restoreObj.Complete += (sender, evtargs) =>
                    {
                       //on competion callback
                    };
    
                    restoreObj.SqlRestoreAsync(srv);
    
                }
                return true;
            }
