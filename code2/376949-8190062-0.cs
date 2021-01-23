    //small example
    public void myFunc()
    {
        string CustNo, Phone, Fax, Email, Type, FaxStat, FaxPro, EmailStat, EmailPro;
    
        //set up query and reader
        //...
        while(reader.read())
        {
             CustNo = reader["CUSTNO"].ToString();
             //etc.
        }
        //reader.close(); conn.close();
    }
