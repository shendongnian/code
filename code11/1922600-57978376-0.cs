    try
    {
        DataView view = new DataView(iDT);
        view.RowFilter = "serialno = " + HRDT.Rows[i].Field<string>(HRDT.Columns.IndexOf("HRDevices"));
        LMTF.LogMessageToFile("Device serial is : "+ HRDevice + " And temp is " + temp);
        int ipRows = view.Count;
        string ipString = ipRows.ToString();
        LMTF.LogMessageToFile(HRDName + " have " + ipString + " transaction.");
    }
