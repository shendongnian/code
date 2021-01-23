    // create your datatable in the form of the newly created sql type
    var dt = new DataTable();
    dt.Columns.Add("TestName", typeof(String));
    dt.Columns.Add("Result", typeof(Decimal));
    dt.Columns.Add("NonNumericResult", typeof(String));
    dt.Columns.Add("QuickLabDumpid", typeof(String));
    // add all your rows here (maybe do it in steps of a thousand
    // 100 Million over the pipe at once is ill-advised)
    // call the following code to hit sql
    using (var cnx = new SqlConnection("your connection string"))
    using (var cmd = new SqlCommand("dbo.Insert_TestResults", cnx) { CommandType = CommandType.StoredProcedure })
    {
        // add the parameter as SqlDbType.Structured
        cmd.Parameters.Add(new SqlParameter("@testResultUpload", dt) { SqlDbType = SqlDbType.Structured });
        try
        {
            cnx.Open();
            cmd.ExecuteNonQuery();
        }
        catch
        {
            // your exception handling here
            throw;
        }
    }
