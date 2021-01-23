    public interface IServiceLocator
    {
        T Create<T>();
    }
    public class NinjectServiceLocator : IServiceLocator
    {
        private readonly IKernel kernel;
        public NinjectServiceLocator(IKernel kernel)
        {
            this.kernel = kernel;
        }
        public T Create<T>()
        {
            return kernel.Get<T>();
        }
    }
    public class ServiceLocator
    {
        private static IServiceLocator current;
        public static IServiceLocator Current
        {
            get
            {
                return current;
            }
            set
            {
                current = value;
            }
        }
        public T Create<T>()
        {
            return current.Create<T>();
        }
    }
