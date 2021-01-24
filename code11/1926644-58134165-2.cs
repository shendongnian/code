    [WebMethod]
    public string GetAkontasByMjesto(string Mjesto)
    {
        OracleConnection conn = new OracleConnection("DATA SOURCE=test-1:1521/fba;USER ID=test;PASSWORD=test");
        OracleDataAdapter dr = new OracleDataAdapter("Select * from AKONTAS where lower(MJESTO) ='" + Mjesto.ToLower() + "'", conn);
        DataSet ds = new DataSet();
        ds.Tables.Add("AKONTAS");
        dr.Fill(ds, "AKONTAS");
        DataTable tt = ds.Tables[0];
        return ds.GetXml();
    }
