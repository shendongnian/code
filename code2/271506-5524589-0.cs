    public class ContextWrapper : DbContext
    {
        public ContextWrapper(string ConnectionStringName)
            : base("name=" + ConnectionctionStringName)
        { }
    }
