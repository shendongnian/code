    class Program
        {
            static void Main(string[] args)
            {
                // -1E-06x^6 + 0.0001x^5 - 0.0025x^4 + 0.0179x^3 + 0.0924x^2 - 0.6204x + 55.07
                var done = false;
                while(!done)
                {
                    double x;
                    if (!Prompt("X> ", out x, out done))
                    {
                        if (done) break;
                    }
                    var sum = Calculate(x);
                    Console.WriteLine("Result = {0}", sum);
                }
    
    
    
    #if DEBUG
                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();
    #endif
            }
    
            private static double Calculate(double x)
            {
                Console.WriteLine("Calculating -1E-06x^6 + 0.0001x^5 - 0.0025x^4 + 0.0179x^3 + 0.0924x^2 - 0.6204x + 55.07");
                var coefficients = new double[] { -1e-6, +1e-4,-2.5e-3,+1.79e-2,9.24e-2,6.204e-1, 5.507e1 };
                var powers = new double[] { 6,5,4,3,2,1,0 };
    
                var sum = 0.0;
                for(var i=0;i<coefficients.Length;i++)
                {
                    var termValue = coefficients[i] * Math.Pow(x, powers[i]);
                    sum += termValue;
                    Console.WriteLine("Sum [{0}x^{1}] = {2}", coefficients[i],powers[i],termValue);
                }
    
                return sum;
    
                //var result = -1E-6*Math.Pow(x,6) + 1E-4*Math.Pow(x,5) - 2.5E-4*Math.Pow(x,4) + 1.79E-2*Math.Pow(x,3)
            }
    
            static bool Prompt(string prompt, out double value, out bool done)
            {
                done=false;
                var validInput = false;
    
                Console.Write("X> ");
                var xString = string.Empty;
                if(!(validInput = double.TryParse(xString = Console.ReadLine(),out value)))
                {
                    done = xString.ToLower()=="quit";
                }
    
                return validInput;
    
            }
