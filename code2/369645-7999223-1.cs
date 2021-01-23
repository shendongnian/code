    #region downcast to int
    public static int CastAsInt( this DataRow row , int index )
    {
        return toInt( row[index] ) ;
    }
    public static int CastAsInt( this DataRow row , string columnName )
    {
        return toInt( row[columnName] ) ;
    }
    public static int? CastAsIntNullable( this DataRow row , int index )
    {
        return toIntNullable( row[index] );
    }
    public static int? CastAsIntNullable( this DataRow row , string columnName )
    {
        return toIntNullable( row[columnName] ) ;
    }
    #region conversion helpers
    private static int toInt( object o )
    {
        int value = (int)o;
        return value;
    }
    private static int? toIntNullable( object o )
    {
        bool hasValue = !( o is DBNull );
        int? value    = ( hasValue ? (int?) o : (int?) null ) ;
        return value;
    }
    #endregion conversion helpers
    #endregion downcast to int
