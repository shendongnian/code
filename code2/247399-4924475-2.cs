    Fluently.Configure().Database(
    						MsSqlConfiguration.MsSql2005
    							.ConnectionString(
    								ConfigurationManager.ConnectionStrings["my"].ConnectionString).ShowSql())
    						.Mappings(m => m.FluentMappings.AddFromAssemblyOf<MyClass>())
    						.BuildSessionFactory();
