    public static class BaseModule
    {
        public static string UsedSource {get; set;}
        
        public static Write(string text)
        {
            OtherStaticClass.Log(UsedSource, text);
        }
    }
    
    internal class Writer : IDisposable
    {
        string _lastSource;
        
        public Writer(string source)
        {
            _lastSource = BaseModule.UsedSource;
            BaseModule.UsedSource = source;
        }
	
        public void Dispose()
        {
            BaseModule.UsedSource = _lastSource;
        }
    }
    internal abstract class Module
    {
        public abstract Source { get; };
	
        public void Write(string text)
        {
            using (var writer = new Writer(Source))
            {
                BaseModule.Write(text);
            }
        }	
    }	
    internal class ModuleA : Module
    {	
        public override Source => "A";
    }
    internal class ModuleB : Module
    {	
        public override Source => "B";
    }
