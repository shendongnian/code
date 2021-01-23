    interface INamed { 
        string Name { get; }
    }
    public class MyList<T> where T : INamed 
        public T[] items;
        public T Get( string name ) {
            foreach( T item in items ) {
            if( item.Name == name )
                return item;
            }
            return null; // if not found
        }
    }
