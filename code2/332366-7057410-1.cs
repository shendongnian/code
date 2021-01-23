    public static T Parse<T> ( string value, bool ignoreCase = false) where T : struct, IComparable, IFormattable, IConvertible
        {
            if ( !typeof ( T ).IsEnum )
                throw new ArgumentException( string.Format( "The type ({0}) must be an enum", typeof ( T ).FullName ) );
            if ( !Enum.IsDefined ( typeof ( T ), value ) )
                throw new ArgumentException( string.Format( "{0} is not defined for the enum {1}", value, typeof ( T ).FullName ) );
            return ( T )Enum.Parse ( typeof ( T ), value, ignoreCase );
        }
