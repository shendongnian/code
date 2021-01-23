    class SqllErrorNumbers
    { 
       public const int BadObject = 208;
       public const int DupKey = 2627;
    }
    
    try
    {
       ...
    }
    catch(SqlException sex)
    {
       foreach(SqlErrorCode err in sex.Errors)
       {
          switch (err.Number)
          {
          case SqlErrorNumber.BadObject:...
          case SqllErrorNumbers.DupKey: ...
          }
       }
    }
