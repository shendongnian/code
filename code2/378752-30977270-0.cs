    public static IEnumerable<T> Method<T>( this IList<T> source ){... }
    public static IEnumerable<T> Method<T>( this IEnumerable<T> source )
    {
        /*input checks on source parameter here*/
        return Method( source.ToList() );
    }
