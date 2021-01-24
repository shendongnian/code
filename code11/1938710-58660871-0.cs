    using System;
    namespace Tester
    {
        class test 
        {
            // What Pow actually does:
            static double logPow(double x, int y) {
                var old = x; // Hold the x
                for (var i = 0; i < y; i++){ // do it y times
                    x = old * x; // Multiply with it's first self
                }
                return x;
            }
            static int counter = 0;
            static double Pow(double x, int y) {
                counter++;
                Console.Write("Recursive action[" + counter + "] Y status ["+ y +"] : ");
                if (y == 0)
                {
                    Console.Write("return 1.0 = " + logPow(x, y) + " \n");
                    return 1.0;
                }
                else
                {
                    Console.Write("return " + x + " * Pow(" + x + ", " + y + " - 1) = " + logPow(x,y-1) + " \n");
                    return x * Pow(x, y - 1);
                }
            }
            static void Main() {
                Console.Write("Last Result : " + Pow(2, 5)); 
            }
        }
    }
