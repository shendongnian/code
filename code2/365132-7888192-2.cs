    using W3b.Sine;
    
    public class ExpressionSample {
    
        public static void Main(String[] args) {
            
            Dictionary<String,BigNum> symbols = new Dictionary<String,BigNum>() {
                {"x", 100} // the implicit conversion defined
            };
        
            Expression expression = new Expression("1 + 2 / 3 * x");
            BigNum result = expression.Evaluate( symbols );
            Console.WriteLine( expression.ExpressionString + " == " + result.ToString() );
            
            BigNum x = 100;
            BigNum xPow100 = x.Pow( 100 );
            Console.WriteLine("100^100 == " + xPow100.ToString() );
            
        }
    }
