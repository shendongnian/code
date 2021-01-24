    public ResultStatus InsertDownload(object log)
     {
     if(log is UserLog userLog)
      {
      return glDb.UsersDownload(userLog);
      }
     else if(log is NonUserLog nonUserLog)
      {
      return glDb.NonUsersDownload(nonUserLog);
      }
     else
      {
      throw new ArgumentException("invalid type", nameof(log));
      }
     }
