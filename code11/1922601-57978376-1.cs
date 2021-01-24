    try
    {
        DataView view = new DataView(iDT);
        view.RowFilter = "serialno = " + temp);
        LMTF.LogMessageToFile("Device serial is : "+ HRDevice + " And temp is " + temp);
        int ipRows = view.Count;
        string ipString = ipRows.ToString();
        LMTF.LogMessageToFile(HRDName + " have " + ipString + " transaction.");
    }
