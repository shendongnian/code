    public class Person : Entity
    {
        public Person(DataContext context)
        {
            ServiceContext = context;
        }
        public virtual DataContext ServiceContext { get; set; }
        public string FirstName { get; set; }
    }
    builder.Register<DataContext>(c => new DataContext(connectionString)).InstancePerHttpRequest();
    builder.RegisterAssemblyTypes(typeof (Person).Assembly)
        .Where(t => t.IsAssignableFrom(typeof (Entity)));
