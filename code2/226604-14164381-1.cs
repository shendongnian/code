    while (true)
    {
        string Message = "";
        int Status = -1;
        bool bStatus;
        OracleParameter param;
        try
        {
            OracleCommand dbmsAlert = new OracleCommand();
            dbmsAlertScan.SQL.Add("call dbms_alert.WaitOne('XYZ', :Message, :Status, 0)"); //Last parameter indicate wait time
            param = new OracleParameter("Message", OracleDbType.Varchar2, ParameterDirection.Output);
            dbmsAlert.Parameters.Add(param); 
            param = new OracleParameter("Status", OracleDbType.Varchar2, ParameterDirection.Output);
            dbmsAlert.Parameters.Add(param); 
            OracleParameter.ExceuteNonQuery();
            Message = dbmsAlert.Parameters["Message"].Value.ToString();
            bStatus = int.TryParse(dbmsAlert.Parameters["Status"].Value.ToString(), out Status);
            if (Status == 0) //0 = Alert Received, 1 = Timed out
            {
                //notify or do ur stuff
            }
        }
        catch (Exception Exp)
        {
            //raise an error
        }
    }
}
