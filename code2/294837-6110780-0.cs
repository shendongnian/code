            string processedCONString = "SERVER=localhost;" +
                                   "DATABASE=discovery;" +
                                   "UID=;" +
                                   "PASSWORD=;"+
                                   "connection timeout=500000";
        MySqlConnection processCON = new MySqlConnection(processedCONString);
        string mySQLCOMMAND = "update "+ siteString+"_discovery "+
            "set processed = b'0' "
            +"WHERE URL not in (select URL from live where URL = " + siteString + ")";
        MySqlCommand mysqlprocessCmdInsertItem = new MySqlCommand(mySQLCOMMAND, processCON);
        processCON.Open();
        mysqlprocessCmdInsertItem.ExecuteNonQuery();
        processCON.Close();
