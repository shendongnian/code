    CrystalReportViewer1.RefreshReport();
    String ssCustomer = Session["ssCustomer"].ToString();
    string strconstring = ConfigurationManager.ConnectionStrings["ONLINE_BANKING2_ConnectionString"].ConnectionString;
    string sqlquery2;
    sqlquery2 = "SELECT [account_number],[customer_id] from customer_details where customer_id = '" + ssCustomer + "'";
    SqlConnection mycon2 = new SqlConnection(strconstring);
    SqlCommand cmd = new SqlCommand(sqlquery2, mycon2);
    mycon2.Open();
    SqlDataReader myreader = cmd.ExecuteReader();
    myreader.Read();
    string accountnumber = myreader["account_number"].ToString();
    string customerID = myreader["customer_id"].ToString();
    myreader.Close();
    mycon2.Close();
    
    ParameterDiscreteValue objDiscreteValue;
    ParameterField objParameterField;
    //specify all the database Login details
    CrystalReportViewer1.LogOnInfo[0].ConnectionInfo.ServerName = "CJ-PC";
    CrystalReportViewer1.LogOnInfo[0].ConnectionInfo.UserID = "sa";
    CrystalReportViewer1.LogOnInfo[0].ConnectionInfo.Password = "123";
    CrystalReportViewer1.LogOnInfo[0].ConnectionInfo.DatabaseName = "online_banking2";
    //Set value for first parameter
    objDiscreteValue = new ParameterDiscreteValue();
    objDiscreteValue.Value = accountnumber;
    objParameterField = CrystalReportViewer1.ParameterFieldInfo["@account_number"];
    objParameterField.CurrentValues.Add(objDiscreteValue);
    CrystalReportViewer1.ParameterFieldInfo.Add(objParameterField);
    objParameterField = CrystalReportViewer1.ParameterFieldInfo["@customer_id"];
    objDiscreteValue = new ParameterDiscreteValue();
    objDiscreteValue.Value = customerID;
    objParameterField.CurrentValues.Add(objDiscreteValue);
    CrystalReportViewer1.ParameterFieldInfo.Add(objParameterField);
