    <connectionStrings>
        <add name="Development" connectionString="Enlist=false;MultipleActiveResultSets=True;Data Source=MYPC\SQLEXPRESS;Initial Catalog=Development;Integrated Security=True" providerName="System.Data.SqlClient"/>
        <add name="Production" connectionString="Enlist=false;MultipleActiveResultSets=True;Data Source=MYPC\SQLEXPRESS;Initial Catalog=Production;Integrated Security=True" providerName="System.Data.SqlClient"/>
    </connectionStrings>
    public class MySession : ISession
    {
        public MySession(string connectionName)
        {
            // ...
        }
    }
    ObjectFactory.Initialize(
        x =>
        {
             x.For<ISession>()
              .Use<MySession>().Ctor<string>("connectionName").Is("Development");
              //.Use<MySession>().Ctor<string>("connectionName").Is("Production");
        }
