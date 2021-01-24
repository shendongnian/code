    // make abstract base class
    public abstract class BaseVersionAssembly
    {
        public abstract string example();
    }
    
    public class VersionAssembly260 : BaseVersionAssembly
    {
        public override string example()
        {
            return "v26";
        }
    }
    
    public class VersionAssembly250 : BaseVersionAssembly
    {
        public override string example()
        {
            return "v25";
        }
    }
    
    public class VersionAssembly240 : BaseVersionAssembly
    {
        public override string example()
        {
            return "v24";
        }
    
    
    }
   
