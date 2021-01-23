    using System;
    
    public abstract class Base 
    {
        public static T Create<T>() where T : Base
        {
            return Activator.CreateInstance<T>();
        }
    
    }
