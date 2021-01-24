    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    
    namespace ConsoleApp3
    {
        class Program
        {
            class Sprite
            {
                private bool _isActive;
                public void SetActive(bool isActive)
                {
                    _isActive = isActive;
                }
            }
            static void Main(string[] args)
            {
                List<Sprite> sl = new List<Sprite>();
                for(int i = 0; i<100; i++)
                {
                    sl.Add(new Sprite());
                }
    
                Stopwatch spw = new Stopwatch();
                spw.Restart();
                for (int i = 0; i < 50; i++)
                {
                    sl[i].SetActive(false);
                }
                Console.Write(1e6 * spw.ElapsedTicks / TimeSpan.TicksPerSecond);
                Console.WriteLine(" microseconds");
                Console.ReadLine();
    
            }
        }
    }
