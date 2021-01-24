    public DataTable ReadCsv(string filename, bool hasHeaders = true, string delimiter = ",")
    {
        var dt = new System.Data.DataTable();
        
        var fi = new System.IO.FileInfo(filename);
        
        var connStr = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"{0}\";Extended Properties='text;HDR={1};FMT=Delimited({2})';",
                                    fi.DirectoryName,
                                    ((hasHeaders) ? "Yes" : "No"),
                                    delimiter);
                                    
        var commStr = string.Format("SELECT * FROM [{0}]", fi.Name);
        
        using (var conn = new System.Data.OleDb.OleDbConnection(connStr))
        using (var cmd = new System.Data.OleDb.OleDbCommand(commStr, conn))
        using (var adapter = new System.Data.OleDb.OleDbAdapter(cmd))
        {
            adapter.Fill(dt);
        }
        
        return dt;
    }
