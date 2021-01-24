    public class AppDomainWrapper : MarshalByRefObject
    {
        public void DoSomething()
        {
            var app = new MyApp();
            app.Initialize();
            ...
            app.Shutdown();
        }
    }
