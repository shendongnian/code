    public class CoHandler : Attribute
    {
        private Type _Type;
    
        public CoHandler(Type type)
        {
           _Type = type;
    
           // Use reflection to validate type argument to see if it has 
           // inherited from ErrorHandler  and check if its has parameterless 
           // constructor
        }
    
        public ErrorHandler GetHandler()
        {
            return (ErrorHandler)Activator.CreateInstance(_Type);
        }
    
    }
