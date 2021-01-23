    class Program
    {
        private enum Cats { Fluffy, Furry, Bald };
        private enum Dogs { Big, Fat, Ugly };
        static void Main ( string [] args )
        {
            var testValue = "Fluffy";
            Cats? tempCat;
            Dogs? tempDog;
           if(  TryParse( testValue, false, out tempCat ) )
               Console.WriteLine ( "'{0}' was parsed to a cat", testValue );
            testValue = "Ugly";
            if ( TryParse ( testValue, false, out tempDog ) )
                Console.WriteLine ( "'{0}' was parsed to a dog", testValue );
            Console.ReadKey ( );
        }
        public static bool TryParse<T> ( string value, bool ignoreCase, out T? result ) where T : struct, IComparable, IFormattable, IConvertible
        {
            result = null;
            if ( !Enum.IsDefined ( typeof ( T ), value ) )
                return false;
            result = ( T )Enum.Parse ( typeof ( T ), value, ignoreCase );
            return true;
        }
    }
