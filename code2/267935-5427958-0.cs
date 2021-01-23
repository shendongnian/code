    string theUserId = Session["UserID"].ToString();
    {
        OdbcConnection cn = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver}; Server=localhost; Database=gymwebsite2; User=root; Password=commando;");
        cn.Open();
    }
