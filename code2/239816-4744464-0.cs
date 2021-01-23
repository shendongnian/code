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
