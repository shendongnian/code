    using System;
    using MathNet.Numerics.Distributions;
    
    namespace Tinv
    {
        class Program
        {
            public static double T_INV_2T(double p, double nu)
            {
                return StudentT.InvCDF(location:0.0, scale:1.0, freedom: nu, p: 1.0 - p/2.0);
            }
    
            static void Main(string[] args)
            {
                var x = T_INV_2T(0.05, (double)8);
                Console.WriteLine($"Output = {x}");
            }
        }
    }
