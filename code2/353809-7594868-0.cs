    class A : IHasClient
    {
        // Id etc
        public virtual Client Client { get; set; }
    }
    class SomeOther : IHasClient
    {
        // Id etc
        public virtual Client Client { get; set; }
    }
    var classesWithClients = session.QueryOver<IHasClient>().List();
