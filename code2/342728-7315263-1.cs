    public interface IClass
    {
        void SaveObject(); // use the signature only here -- no logic; you cannot use access modifiers like "public"
    }
    
    public class ClassOne : IClass
    {
        // other stuff
    
        public void SaveObject()
        {
            // save logic for this class
        }
    }
    
    public class ClassTwo : IClass
    {
        // other stuff
    
        public void SaveObject()
        {
            // different save logic for this class
        }
    }
