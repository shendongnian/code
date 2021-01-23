    // create your datatable in the form of the newly created sql type
    var dt = new DataTable();
    dt.Columns.Add("TestName", typeof(String));
    dt.Columns.Add("Result", typeof(Nullable<Decimal>)); 
    dt.Columns.Add("NonNumericResult", typeof(String));
    dt.Columns.Add("QuickLabDumpid", typeof(String));
    
    // add all your rows here (maybe do it in steps of 1000)
    
    // add the parameter as SqlDBType.Structured
    cmd.Parameters.Add(new SqlParameter("@testResultUpload", testResultUpload){SqlDbType = SqlDbType.Structured});
