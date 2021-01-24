    internal static class StringExtensions
    {
        /// <summary>Performs a CurrentCultureIgnoreCase equality check.</summary>
        public static Boolean Eq( this String x, String y )
        {
            return String.Equals( x, y, StringComparison.CurrentCultureIgnoreCase );
        } 
    }
