    public class ContextFactory : IContextFactory
    {
        public EntityContext Get()
        {
            var connectionString = ... // Do some logic to get the connection string
            return new EntityContext(connectionString);
        }
    }
    ...
    using (var context = new ContextFactory().Get())
    {
        ...
    }
