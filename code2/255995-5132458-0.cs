    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            double[,] source = new double[1000, 1000];
            int iterations = 1000;
            
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                UsingCast(source);
            }
            sw.Stop();
            Console.WriteLine("LINQ: {0}", sw.ElapsedMilliseconds);
    
            sw = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                UsingForLoop(source);
            }
            sw.Stop();
            Console.WriteLine("For loop: {0}", sw.ElapsedMilliseconds);
    
            GC.Collect();
            GC.WaitForPendingFinalizers();
            
            sw = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                UsingBlockCopy(source);
            }
            sw.Stop();
            Console.WriteLine("Block copy: {0}", sw.ElapsedMilliseconds);
        }
        
        
        static List<double> UsingCast(double[,] array)
        {
            return array.Cast<double>().ToList();
        }
    
        static List<double> UsingForLoop(double[,] array)
        {
            int width = array.GetLength(0);
            int height = array.GetLength(1);
            List<double> ret = new List<double>(width * height);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    ret.Add(array[i, j]);
                }
            }
            return ret;
        }
        
        static List<double> UsingBlockCopy(double[,] array)
        {
            double[] tmp = new double[array.GetLength(0) * array.GetLength(1)];    
            Buffer.BlockCopy(array, 0, tmp, 0, tmp.Length * sizeof(double));
            List<double> list = new List<double>(tmp);
            return list;
        }
    }
