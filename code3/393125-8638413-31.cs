    // create your datatable in the form of the newly created sql type
    var dt = new DataTable();
    dt.Columns.Add("TestName", typeof(String));
    dt.Columns.Add("Result", typeof(Decimal));
    dt.Columns.Add("NonNumericResult", typeof(String));
    dt.Columns.Add("QuickLabDumpid", typeof(String));
    
    // add all your rows here (maybe do it in steps of a thousand
    // 100 Million over the pipe at once is ill-advised)
    
    // add the parameter as SqlDBType.Structured
    cmd.Parameters.Add(new SqlParameter("@testResultUpload", dt){SqlDbType = SqlDbType.Structured});
