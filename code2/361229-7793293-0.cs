    public class GenericDisposable<T> : IDisposable
    {
        public Action Dispose { get; set; }
        public T Object { get; set; }
        void IDisposable.Dispose()
        {
            Dispose();
        }
    
    }
    public static GenericDisposable<T> CreateDomainWithType<T>()
    {
        var appDomain = AppDomain.CreateDomain("test-domain");
        var inst = appDomain.CreateInstanceAndUnwrap(typeof(T).Assembly.FullName, typeof(T).FullName);
        appDomain.DomainUnload += (a, b) => Console.WriteLine("Unloaded");
        return new GenericDisposable<T>() { Dispose = () => AppDomain.Unload(appDomain), Object = (T)inst };
    }
    public class User : MarshalByRefObject
    {
        public void Sayhello()
        {
            Console.WriteLine("Hello from User");
        }
    }
     
    //Usage              
    static void Main()
    {
        using (var wrap = CreateDomainWithType<User>())
        {
            wrap.Object.Sayhello();
        }
        Console.Read();
    }
