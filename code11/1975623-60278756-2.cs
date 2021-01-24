    private Task<DataView> GetDataAsync()
    {
        return Task.Run(() =>
        {
            string connectionStringDE = "Driver={Pervasive ODBC Client Interface};ServerName=DE875;dbq=@DEDBFS;Uid=DEUsername;Pwd=DEPassword;";
            string queryStringDE = "select NRO,NAME,NAMEA,NAMEB,ADDRESS,POSTA,POSTN,POSTADR,COMPANYN,COUNTRY,ID,ACTIVE from COMPANY";
            string connectionStringFR = "Driver={Pervasive ODBC Client Interface};ServerName=FR875;dbq=@FRDBFS;Uid=FRUsername;Pwd=FRPassword;";
            string queryStringFR = "select NRO,NAME,NAMEA,NAMEB,ADDRESS,POSTA,POSTN,POSTADR,COMPANYN,COUNTRY,ID,ACTIVE from COMPANY";
            DataTable dataTable = new DataTable("COMPANY");
            // using-statement will cleanly close and dispose unmanaged resources i.e. IDisposable instances
            using (OdbcConnection dbConnectionDE = new OdbcConnection(connectionStringDE))
            {
                dbConnectionDE.Open();
                OdbcDataAdapter dadapterDE = new OdbcDataAdapter();
                dadapterDE.SelectCommand = new OdbcCommand(queryStringDE, dbConnectionDE);
                dadapterDE.Fill(dataTable);
            }
            using (OdbcConnection dbConnectionFR = new OdbcConnection(connectionStringFR))
            {
                dbConnectionFR.Open();
                OdbcDataAdapter dadapterFR = new OdbcDataAdapter();
                dadapterFR.SelectCommand = new OdbcCommand(queryStringFR, dbConnectionFR);
                var newTable = new DataTable("COMPANY");
                dadapterFR.Fill(newTable);
                dataTable.Merge(newTable);
            }
            return dataTable.DefaultView;
        });
    }
