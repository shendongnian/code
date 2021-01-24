    public interface ISmthResolver
    {
        ISomeLibrary Get(string arg);
    }
    
    ...
    
    public class SmthResolver : ISmthResolver
    {
        private readonly ConcurrentDictionary<string, Lazy<ISomeLibrary>> _instances = new ConcurrentDictionary<string, Lazy<ISomeLibrary>>();
    
        public ISomeLibrary Get(string arg) => _instances.GetOrAdd(arg, key => new Lazy<ISomeLibrary>(() => new SomeLibrary())).Value;
    }
    
    ...
    
    services.AddSingleton<SmthResolver, ISmthResolver>();
    
    ...
    
    public class Some
    {
        public Some(ISmthResolver sr)
        {
            var sl = sr.Get("arg");
        }
    }
