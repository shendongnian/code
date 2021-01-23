     public MyDBContext(DBConnectionType ConnectionType) //: base("ConnMain")
      {
          if(ConnectionType==DBConnectionType.MainConnection)
           {
             this.Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnMain"].ConnectionString;
           }
          else if(ConnectionType==DBConnectionType.BackupConnection)
           {
             this.Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnBackup"].ConnectionString;
           }
      }
