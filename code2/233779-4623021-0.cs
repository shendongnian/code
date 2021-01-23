    string casetype6(HiddenField HiddenField1,DropDownList DropDownList3)
    {
        String casetype1="";
        try
        {
            OdbcConnection casetype = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};Server=10.155.160.130;Database=testcase;User=root;Password=;Option=3;");
            casetype.Open();
            //************to get case type    
            string casetypequery = "select casename from casetype where skey=?";
            //************to get case type
            OdbcCommand casetypecmd = new OdbcCommand(casetypequery, casetype);
            String casetypefromdropdown = DropDownList3.SelectedItem.ToString();
            casetypecmd.Parameters.AddWithValue("?", casetypefromdropdown);
            using (OdbcDataReader casetypeMyReader = casetypecmd.ExecuteReader())
            {
                while (casetypeMyReader.Read())
                {
                    String casename = casetypeMyReader["casename"].ToString();
                    HiddenField1.Value = casename;
                    casetype1 = HiddenField1.Value.ToString();
                    break; // instead of returning from here, break the loop
                }
            }
        }
        catch(Exception ep)
        { }
        return casetype1; // and return here.
    }
