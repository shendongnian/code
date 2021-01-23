    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public interface IPeople
    {
        IList<User> GetPeople(int id);
         
    }
    public class Friends : IPeople
    {
        public IList<User> GetPeople(int id)
        {
            return new List<User>();
        }
        
        public class Fans : IPeople
        {
            public IList<User> GetPeople(int id)
            {
                return new List<User>();
            }
        }
        public class Program
        {
            static void Main(string[] args)
            {
                var builder = new ContainerBuilder();
                builder.RegisterType<Friends>().Named<IPeople>("Friends");
                builder.RegisterType<Fans>().Named<IPeople>("Fans");
                IContainer c = builder.Build();
                var x = c.ResolveNamed<IPeople>("Friends");
            }
        }
    }
