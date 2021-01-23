    object dbValue = 5;
    //this throws
    Convert.ChangeType(dbValue, typeof(int?));
    //this works
    if(dbValue == DBNull.Value || dbValue == null) 
    {
      if(typeof(int?).IsNullable) //or is a class, like string
      {return null;}
      dbValue = null;
    }
    var type = GetUnderlyingType<int?>(); //== typeof(int)
    Convert.ChangeType(dbValue, type);
