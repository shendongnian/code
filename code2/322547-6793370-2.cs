    public static class DataRowExtensions
    {
        #region downcast to DateTime
        public static DateTime CastAsDateTime( this DataRow row , int index )
        {
            return toDateTime( row[index] ) ;
        }
        public static DateTime CastAsDateTime( this DataRow row , string columnName )
        {
            return toDateTime( row[columnName] ) ;
        }
        public static DateTime? CastAsDateTimeNullable( this DataRow row , int index )
        {
            return toDateTimeNullable( row[index] );
        }
        public static DateTime? CastAsDateTimeNullable( this DataRow row , string columnName )
        {
            return toDateTimeNullable( row[columnName] ) ;
        }
        #region conversion helpers
        private static DateTime toDateTime( object o )
        {
            DateTime value = (DateTime)o;
            return value;
        }
        private static DateTime? toDateTimeNullable( object o )
        {
            bool  hasValue = !( o is DBNull );
            DateTime? value    = ( hasValue ? (DateTime?) o : (DateTime?) null ) ;
            return value;
        }
        #endregion
        #endregion downcast to DateTime
        #region downcast to byte[]
        public static byte[] CastAsByteArray( this DataRow row , int index )
        {
            return toByteArray( row[index] );
        }
        public static byte[] CastAsByteArray( this DataRow row , string columnName )
        {
            return toByteArray( row[columnName] );
        }
        #region conversion helpers
        private static byte[] toByteArray( object o )
        {
            bool   hasValue = !( o is DBNull );
            byte[] value    = ( hasValue ? (byte[]) o : (byte[]) null ) ;
            return value;
        }
        #endregion
        #endregion downcast to Byte[]
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
        #endregion
        #endregion downcast to int
        #region downcast to decimal
        public static decimal CastAsDecimal( this DataRow row , int index )
        {
            return toDecimal( row[index] ) ;
        }
        public static decimal CastAsDecimal( this DataRow row , string columnName )
        {
            return toDecimal( row[columnName] ) ;
        }
        public static decimal? CastAsDecimalNullable( this DataRow row , int index )
        {
            return toDecimalNullable( row[index] );
        }
        public static decimal? CastAsDecimalNullable( this DataRow row , string columnName )
        {
            return toDecimalNullable( row[columnName] ) ;
        }
        #region conversion helpers
        private static decimal toDecimal( object o )
        {
            decimal value = (decimal)o;
            return value;
        }
        private static decimal? toDecimalNullable( object o )
        {
            bool     hasValue = !( o is DBNull );
            decimal? value    = ( hasValue ? (decimal?) o : (decimal?) null ) ;
            return value;
        }
        #endregion
        #endregion downcast to decimal
        #region downcast to double
        public static double CastAsDouble( this DataRow row , int index )
        {
            return toDouble( row[index] ) ;
        }
        public static double CastAsDouble( this DataRow row , string columnName )
        {
            return toDouble( row[columnName] ) ;
        }
        public static double? CastAsDoubleNullable( this DataRow row , int index )
        {
            return toDoubleNullable( row[index] );
        }
        public static double? CastAsDoubleNullable( this DataRow row , string columnName )
        {
            return toDoubleNullable( row[columnName] ) ;
        }
        #region conversion helpers
        private static double toDouble( object o )
        {
            double value = (double)o;
            return value;
        }
        private static double? toDoubleNullable( object o )
        {
            bool     hasValue = !( o is DBNull );
            double? value    = ( hasValue ? (double?) o : (double?) null ) ;
            return value;
        }
        #endregion
        #endregion downcast to double
        #region downcast to bool
        public static bool CastAsBool( this DataRow row , int index )
        {
            return toBool( row[index] ) ;
        }
        public static bool CastAsBool( this DataRow row , string columnName )
        {
            return toBool( row[columnName] ) ;
        }
        public static bool? CastAsBoolNullable( this DataRow row , int index )
        {
            return toBoolNullable( row[index] );
        }
        public static bool? CastAsBoolNullable( this DataRow row , string columnName )
        {
            return toBoolNullable( row[columnName] ) ;
        }
        #region conversion helpers
        private static bool toBool( object o )
        {
            bool value = (bool)o;
            return value;
        }
        private static bool? toBoolNullable( object o )
        {
            bool  hasValue = !( o is DBNull );
            bool? value    = ( hasValue ? (bool?) o : (bool?) null ) ;
            return value;
        }
        #endregion
        #endregion downcast to bool
        #region downcast to string
        public static string CastAsString( this DataRow row , int index )
        {
            return toString( row[index] );
        }
        public static string CastAsString( this DataRow row , string columnName )
        {
            return toString( row[columnName] );
        }
        #region conversion helpers
        private static string toString( object o )
        {
            bool   hasValue = !( o is DBNull );
            string value    = ( hasValue ? (string) o : (string) null ) ;
            return value;
        }
        #endregion
        #endregion downcast to string
    }
