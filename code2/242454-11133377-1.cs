     string conString = @"Data Source=.\sqlexpress;" +
                            "Database=Northwind;Integrated Security=SSPI;" +
                            "Min Pool Size=5;Max Pool Size=15;Connection Reset=True;" +
                            "Connection Lifetime=600;";
        // Parse the SQL Server connection string and display it's properties
        
        SqlConnectionStringBuilder objSB1 = new SqlConnectionStringBuilder(conString);
        Response.Write("<b>Parsed SQL Connection String Parameters:</b>");
        Response.Write(" <br/>  Database Source = " + objSB1.DataSource);
        Response.Write(" <br/>  Database = " + objSB1.InitialCatalog);
        Response.Write(" <br/>  Use Integrated Security = " + objSB1.IntegratedSecurity);
        Response.Write(" <br/>  Min Pool Size = " + objSB1.MinPoolSize);
        Response.Write(" <br/>  Max Pool Size = " + objSB1.MaxPoolSize);
        Response.Write(" <br/>  Lifetime = " + objSB1.LoadBalanceTimeout);
