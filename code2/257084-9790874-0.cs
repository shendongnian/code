    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    
    namespace StringPerformanceTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                const int n = 10000000;
                int k;
                string time, s1;
                Stopwatch sw;
    
                // List for testing ("1", "2", "3" ...)
                List<string> list = new List<string>(n);
                for (int i = 0; i < n; i++)
                    list.Add(i.ToString());
    
                // Test ByVal
                k = 0;
                sw = Stopwatch.StartNew();
    
                foreach (string s in list)
                {
                    s1 = s;
                    if (StringTestSubVal(s1)) k++;
                }
    
                time = GetElapsedString(sw);
                Console.WriteLine("ByVal: " + time);
                Console.WriteLine("123 found " + k + " times.");
    
    
                // Test ByRef
                k = 0;
                sw = Stopwatch.StartNew();
    
                foreach (string s in list)
                {
                    s1 = s;
                    if (StringTestSubRef(ref s1)) k++;
                }
    
                time = GetElapsedString(sw);
                Console.WriteLine("Time ByRef: " + time);
                Console.WriteLine("123 found " + k + " times.");
            }
    
            static bool StringTestSubVal(string s)
            {
                if (s == "123")
                    return true;
                else
                    return false;
            }
    
            static bool StringTestSubRef(ref string s)
            {
                if (s == "123")
                    return true;
                else
                    return false;
            }
    
            static string GetElapsedString(Stopwatch sw)
            {
                if (sw.IsRunning) sw.Stop();
                TimeSpan ts = sw.Elapsed;
                return String.Format("{0:00}:{1:00}:{2:00}.{3:000}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            }
    
        }
    }
