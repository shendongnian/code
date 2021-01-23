    public string GetNextSId()
    {
        var parameter = new Devart.Data.Oracle.OracleParameter("io_SID", Devart.Data.Oracle.OracleDbType.VarChar, ParameterDirection.Output);
        this.Database.ExecuteSqlCommand("BEGIN P_SID.SID_PGet(:io_SID); END;", parameter);
        var sid = parameter.Value as string;
        return sid;
    }
