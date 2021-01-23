        // Syntactic sugar for declaring a general dispatch table
        // The dictionary maps from a key to a function that can return 
        // a closed delegate given an instance of a class.
        // Note that if keys are always integers then it is simpler to use an
        // array rather than a dictionary.
        public class DispatchTable<Key, Class, Delegate> : Dictionary<Key, Func<Class, Delegate>> 
        {
            // standardise the method for accessing a delegate
            public Delegate GetDelegate(Class c, Key k)
            {
                var d = GetValueOrDefault(k);
                if (d == null)
                {
                    throw new ArgumentException(String.Format("Delegate not found for key [{0}]",k));
                }
                return d(c);
            }                
        };
        
