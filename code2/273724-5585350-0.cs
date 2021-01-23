    public void SharePointConnectionExample1()
    {
        using (SharePointConnection connection = new SharePointConnection(@"
                    Server=mysharepointserver.com;
                    Database=mysite/subsite
                    User=spuser;
                    Password=******;
                    Authentication=Ntlm;
                    TimeOut=10;
                    StrictMode=True;
                    RecursiveMode=RecursiveAll;
                    DefaultLimit=1000;
                    CacheTimeout=5"))
        {
            connection.Open();
            using (SharePointCommand command = new SharePointCommand("UPDATE `mytable` SET `mycolumn` = 'hello world'", connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
