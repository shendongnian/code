    protected void Application_Start(object sender, EventArgs e)
    {
      using (var db = new MyDb())
      {
        if (db.Database.Connection.DataSource.IndexOf("sqlexpress", StringComparison.InvariantCultureIgnoreCase) > -1)
        {
            Database.SetInitializer(new MyDbInitializer());
        }
      }
    }
