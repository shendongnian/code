    // ...
    using System.Linq;
    IEnumerable<T> GetSubset<T>( IEnumerable<T> collection, int start, int len )
    {
        // error checking if desired
        return collection.Skip( start ).Take( len );
    }
