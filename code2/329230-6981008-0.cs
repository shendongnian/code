    public interface IHandler<in T> where T : IConfiguration
    {
        void Handle(T myConfiguration);
    }
 
