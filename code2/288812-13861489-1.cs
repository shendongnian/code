    public class AnObject
    {
        public string AString { get; set; }
        public T Duplicate<T>(T exampleObject)
            where T: new()
        {
            var newInstance = (T)Activator.CreateInstance<T>();
            
            // do some stuff here to newInstance based on this AnObject
            if (typeof (T) == typeof (AnotherObject))
            {
                var another = newInstance as AnotherObject;
                if(another!=null)
                    another.AString = this.AString;
            }
            
            return newInstance;
        }
    }
