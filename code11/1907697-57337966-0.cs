    using System;
    using System.Runtime.InteropServices;
    using AS.HDFql;   // use HDFql namespace (make sure it can be found by the C# compiler)
    namespace MyNamespace
    {
        class Program
        {
            static void Main()
            {
                // dims
                int h = 162;
                int w = 128;
                // read array
                float[] arrFlat = new float[h * w];
                HDFql.Execute("SELECT FROM \\path\\to\\weights.h5 \"/dense1/dense1/kernel:0\" INTO MEMORY " + HDFql.VariableTransientRegister(arrFlat));		
                // reshape
                float[,] arr = new float[h, w];  // row-major
                for (int i = 0; i < h; i++)
                {
                    for (int j = 0; j < w; j++)
                    {
                        arr[i, j] = arrFlat[i * w + j];
                    }
                }
                // show one entry
                Console.WriteLine(arr[13, 87].ToString());
                Console.WriteLine(arrFlat[13 * w + 87].ToString());
                // Keep the console window open in debug mode.
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
