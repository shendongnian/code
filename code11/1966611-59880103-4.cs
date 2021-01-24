    public ResultStatus InsertDownload(Log log)
     {
     if(log.IsUser)
      {
      return glDb.UsersDownload(log);
      }
     else
      {
      return glDb.NonUsersDownload(log);
      }
     }
