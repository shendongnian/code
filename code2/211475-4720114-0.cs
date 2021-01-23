    /// <summary>
    /// 
    /// </summary>
    public static class NumberExtensions
    {
        /// <summary>
        /// Convert string value to decimal ignore the culture.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Decimal value.</returns>
        public static decimal ToDecimal ( this string value )
        {
            decimal number;
            string tempValue = value;
            var punctuation = value.Where ( x => char.IsPunctuation ( x ) ).Distinct ( );
            int count = punctuation.Count ( );
            NumberFormatInfo format = CultureInfo.InvariantCulture.NumberFormat;
            switch ( count )
            {
                case 0:
                    break;
                case 1:
                    tempValue = value.Replace ( ",", "." );
                    break;
                case 2:
                    if ( punctuation.ElementAt ( 0 ) == '.' )
                        tempValue = value.SwapChar ( '.', ',' );
                    break;
                default:
                    throw new InvalidCastException ( );
            }
            number = decimal.Parse ( tempValue, format );
            return number;
        }
        /// <summary>
        /// Swaps the char.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        /// <returns></returns>
        public static string SwapChar ( this string value, char from, char to )
        {
            if ( value == null )
                throw new ArgumentNullException ( "value" );
            StringBuilder builder = new StringBuilder ( );
            foreach ( var item in value )
            {
                char c = item;
                if ( c == from )
                    c = to;
                else if ( c == to )
                    c = from;
                builder.Append ( c );
            }
            return builder.ToString ( );
        }
    }
    [TestClass]
    public class NumberTest
    {
        
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Convert_To_Decimal_Test ( )
        {
            string v1 = "123.4";
            string v2 = "123,4";
            string v3 = "1,234.5";
            string v4 = "1.234,5";
            string v5 = "123";
            string v6 = "1,234,567.89";
            string v7 = "1.234.567,89";
            decimal a1 = v1.ToDecimal ( );
            decimal a2 = v2.ToDecimal ( );
            decimal a3 = v3.ToDecimal ( );
            decimal a4 = v4.ToDecimal ( );
            decimal a5 = v5.ToDecimal ( );
            decimal a6 = v6.ToDecimal ( );
            decimal a7 = v7.ToDecimal ( );
            Assert.AreEqual ( ( decimal ) 123.4, a1 );
            Assert.AreEqual ( ( decimal ) 123.4, a2 );
            Assert.AreEqual ( ( decimal ) 1234.5, a3 );
            Assert.AreEqual ( ( decimal ) 1234.5, a4 );
            Assert.AreEqual ( ( decimal ) 123, a5 );
            Assert.AreEqual ( ( decimal ) 1234567.89, a6 );
            Assert.AreEqual ( ( decimal ) 1234567.89, a7 );
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Swap_Char_Test ( )
        {
            string v6 = "1,234,567.89";
            string v7 = "1.234.567,89";
            string a1 = v6.SwapChar ( ',', '.' );
            string a2 = v7.SwapChar ( ',', '.' );
            Assert.AreEqual ( "1.234.567,89", a1 );
            Assert.AreEqual ( "1,234,567.89", a2 );
        }
    }
