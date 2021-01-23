       public void updateConfigFile(string con)
        {
            //updating config file
            XmlDocument XmlDoc = new XmlDocument();
            //Loading the Config file
            XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
           // XmlDoc.Load("App.config");
            foreach (XmlElement xElement in XmlDoc.DocumentElement)
            {
                if (xElement.Name == "connectionStrings")
                {
                    //setting the coonection string
                    xElement.FirstChild.Attributes[2].Value = con;
                }
            }
            //writing the connection string in config file
            XmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            //XmlDoc.Save("App.config");
        }
     private void btn_Connect_Click(object sender, EventArgs e)
        {
            StringBuilder Con = new StringBuilder("Data Source=");
            Con.Append(txt_ServerName.Text);
            Con.Append(";Initial Catalog=");
            Con.Append(txt_DatabaseName.Text);
            if (String.IsNullOrEmpty(txt_UserId.Text) &&String.IsNullOrEmpty(txt_Password.Text))
                Con.Append(";Integrated Security=true;");
            else
            {
                Con.Append(";User Id=");
                Con.Append(txt_UserId.Text);
                Con.Append(";Password=");
                Con.Append(txt_Password.Text);
            }
            string strCon = Con.ToString();
            updateConfigFile(strCon);
            DatabaseTableDA da = new DatabaseTableDA();
            tableList = da.Select_Tables();
            this.lstTables.DataSource = tableList;
        }
  
