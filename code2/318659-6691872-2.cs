        username=your emailid;
         password=email password;
        app_name="MyNetwork Web Application!";
        DataSet ds = GmailContacts.GetGmailContacts(App_Name, username, password);
        GridView1.DataSource = ds;
        GridView1.DataBind();  
