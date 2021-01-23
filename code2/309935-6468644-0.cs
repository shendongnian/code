    public interface IHasName
    {
        string name;
    }    
    public class MyList<T> where T : IHasName
    {
        public T[] items;
        public Get( string name )
        {
            foreach( T item in items )
            {
                if( item.name == name )
                    return item;
            }
            return null; // if not found
        }
    }
