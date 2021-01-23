    while (reader.Read())
    {
        string CustNo = reader["CUSTNO"].ToString();
        string Phone = reader["PHONE"].ToString();
        string Fax = reader["FAX"].ToString();
        string Email = reader["PRI_EMAIL"].ToString();
        string Type = reader["TYPE"].ToString();
        // Declare your variables here
        string FaxStat, FaxPro, EmailStat, EmailPro;
    
        if (Type.Contains("H"))
        {
            if (Type.Contains("F"))
            {
                string FaxStat = "Y";
                string FaxPro = "PENDING";
            }
            else
            {
                //...
                //...
