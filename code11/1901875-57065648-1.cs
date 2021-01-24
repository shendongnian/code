    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    
    namespace ConsoleApp21
    {
        class Program
        {
            static void Main(string[] args)
            {
                double maxTemp = 255;
                double minTemp = -35;
    
                int pixelValues = 1200;
                byte[][] Lookup = new byte[pixelValues][];
                for (int i = 0; i < Lookup.Length; i++)
                {
                    byte bValue = (byte)i;
                    byte[] b = new byte[3] { bValue, bValue, bValue };
                    Lookup[i] = b;
                }
    
                //Make proto temp readings
                double[] temps = new double[640 * 512];
                
                Random r = new Random();
                for (int i = 0; i < 640 * 512; i++)
                {
                    temps[i] =  r.NextDouble() * maxTemp;
                }
                
                int size = 640 * 512 * 3;
                byte[] imageValues = new byte[size];
                var timings = new List<long>(50);
                for (int i = 0; i < 50; i++)
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    int index = 0;
                    for (int j = 0; j < temps.Length; j++)
                    {
                        var lookupVal = (int)(pixelValues * (temps[j] - minTemp) / (maxTemp - minTemp));
                        byte[] pixel = Lookup[lookupVal];
                        imageValues[index] = pixel[0];
                        imageValues[index + 1] = pixel[1];
                        imageValues[index + 2] = pixel[2];
                        index += 3;
    
                    }
                    sw.Stop();
                    var ms = sw.ElapsedMilliseconds;
                    timings.Add(ms);
                    //Console.WriteLine(sw.ElapsedMilliseconds);
                }
                Console.WriteLine($"Max {timings.Max()} Avg {timings.Average()}");
                Console.ReadKey();
            }
    
        }
    }
