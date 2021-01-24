    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MathNet.Numerics.LinearAlgebra;
    using MathNet.Numerics.OdeSolvers;
    
    namespace Sys
    {
        class Program
        {
            static void Main(string[] args)
            {
                int N = 1000000;
                Vector<double> y0 = Vector<double>.Build.Dense(new[] { -7.0 / 4.0, 55.0 / 8.0 });
                Func<double, Vector<double>, Vector<double>> der = DerivativeMaker();
    
                Vector<double>[] res = RungeKutta.FourthOrder(y0, 0, 10, N, der);
    
                double[] x = new double[N];
                double[] y = new double[N];
                for (int i=0; i <N; i++)
                {
                    double[] temp = res[i].ToArray();
                    x[i] = temp[0];
                    y[i] = temp[1];
                }
    
                //Test
                Console.WriteLine(y[N / 10]); // gives 164,537981852489
                Console.WriteLine(Math.Exp(-1) + 3 * Math.Exp(4) - 5.0 / 2 + 23.0 / 8); //gives 164,537329540604, which is y(1)
    
    
                Console.ReadKey();
    
            }
    
            static Func<double, Vector<double>, Vector<double>> DerivativeMaker()
            {
                return (t, Z) =>
                {
                    double[] A = Z.ToArray();
                    double x = A[0];
                    double y = A[1];
    
                    return Vector<double>.Build.Dense(new[] { x + 2 * y + 2 * t, 3 * x + 2 * y - 4 * t });
    
                };
            }
        }
    }
