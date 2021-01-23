    public class CustomTemplateBase<T> : TemplateBase<T>
    {
        public dynamic Instance { get; set; }
        public dynamic CreateInstance(string typeName)
        {
            Type type = Type.GetType(typeName);
            
            // You'd to your deserialisation here, I'm going to
            // just cheat and return a new instance.
            return Activator.CreateInstance(type);
        }
    }
