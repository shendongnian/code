    class class1
    {
      public DataTable GetPrimaryKeyTables(string localServer, string userName, string password, string selectedDatabase)
      .......
       ........
      return dtListOfPrimaryKeyTables;
      
    }
    class Class2
    {
        protected void BindControl(....)
        {
          DataTable dt = new class1().GetPrimaryKeyTables(......);
          dgResultView.DataSource = dt;
          dgResultView.DataBind();
         }
    }
