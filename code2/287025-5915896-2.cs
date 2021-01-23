    int i = 72; //72 is the value for OleDbType.Guid
    if(Enum.IsDefined(typeof(System.Data.OleDb.OleDbType), i))
    {
    	System.Data.OleDb.OleDbType dbType = (System.Data.OleDb.OleDbType)i;
    	Console.WriteLine(dbType);
    }
    else
    	Console.WriteLine("{0} is not defined for System.Data.OleDb.OleDbType", i);
