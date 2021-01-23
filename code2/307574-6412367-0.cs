    //this was missing in your example and MUST be there to tell ODP how many array elements to expect
    cmd.ArrayBindCount = 2;
     string[] jobTitleArray = {"name1", "name1"};
    var paramNames = new OracleParameter();
    
    //paramNames.CollectionType = OracleCollectionType.PLSQLAssociativeArray;/*once again, you are passing in an array of values to be executed and not a pl-sql table*/
    paramNames.ParameterName = "P_JOB_TITLE";
    //paramNames.Size = 2; /* this is unnecessary since it is for a plsql-associative array
    paramNames.Value =  jobTitleArray ;
    cmd.Parameters.Add(paramNames);
