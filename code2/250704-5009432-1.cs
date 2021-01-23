    public class Part // This is one kind of T
    {
        public static IRepository<Part> Repository { get { return IoC.GetInstance<IRepository<Part>>(); } }
        ...
    }
