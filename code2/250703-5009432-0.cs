    public class Part // This is one kind of T
    {
        public static IRepository<Part> Repository { get { IoC.GetInstance<IRepository<Part>>(); } }
        ...
    }
