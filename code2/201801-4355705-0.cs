    public void ListClientsByType(string clientType)
    {
        using (IDbConnection conn = new SqlConnection("connectionstring"))
        {
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT nam FROM clients WHERE typ = @type";
    
            cmd.Parameters.Add(
                _CreateInputParameter(cmd, DbType.String, "@type", clientType));
    
            conn.Open();
    
            IDataReader dr = null;
    
            try
            {
                dr = cmd.ExecuteReader();
                // Work with results here
            }
            finally
            {
                if (dr != null)
                    dr.Close();
            }
        }
    }
    
    private IDbDataParameter _CreateInputParameter(
        IDbCommand cmd, DbType type, string name, object value)
    {
        IDbDataParameter p = cmd.CreateParameter();
    
        p.DbType = DbType.String;
        p.Direction = ParameterDirection.Input;
        p.ParameterName = name;
        p.Value = value;
    
        return p;
    }
