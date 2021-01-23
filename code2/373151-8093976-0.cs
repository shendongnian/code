    namespace nsDivZero
    {
        using System;
        public class DivZero
        {
            static public void Main ()
            {
                // Set an integer equal to 0
                int IntVal1 = 0;
                // and another not equal to zero
                int IntVal2 = 57;
                try
                {
                    Console.WriteLine ("{0} / {1} = {2}", IntVal2, IntVal1, IntResult (IntVal2, IntVal1) / IntResult (IntVal2, IntVal1));
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine (e.Message);
                }
                // Set a double equal to 0
                double dVal1 = 0.0;
                double dVal2 = 57.3;
                try
                {
                    Console.WriteLine ("{0} / {1} = {2}", dVal2, dVal1, DoubleResult (dVal2, dVal1));
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine (e.Message);
                }
            }
            static public int IntResult (int num, int denom)
            {
                return (num / denom);
            }
            static public double DoubleResult (double num, double denom)
            {
                return (num / denom);
            }
        }
    }
