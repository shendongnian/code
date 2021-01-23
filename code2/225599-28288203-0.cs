    public static class StringEnumerableExtensions {
        public static IEnumerable<T> StringsToEnums<T>( this IEnumerable<string> strs) where T : struct, IConvertible {
            Type t = typeof( T );
            var ret = new List<T>();
            if( t.IsEnum ) {
                T outStr;
                foreach( var str in strs ) {
                    if( Enum.TryParse( str, out outStr ) ) {
                        ret.Add( outStr );
                    }
                }
            }
            return ret;
        }
    }
