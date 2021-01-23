    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace InterfaceFieldConsoleApplication
    {
        class Program
        {
            public abstract class A
            {
                public int Counter;
            }
            public interface IA
            {
                int Counter { get; set; }
            }
            public class B : A, IA
            {
                public new int Counter { get { return base.Counter; } set { base.Counter = value; } }
            }
            static void Main(string[] args)
            {
                var b = new B();
                A a = b;
                IA ia = b;
                const long LoopCount = (int) (100*10e6);
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                for (int i = 0; i < LoopCount; i++)
                    a.Counter = i;
                stopWatch.Stop();
                Console.WriteLine("a.Counter: {0}", stopWatch.ElapsedMilliseconds);
                stopWatch.Reset();
                stopWatch.Start();
                for (int i = 0; i < LoopCount; i++)
                    ia.Counter = i;
                stopWatch.Stop();
                Console.WriteLine("ia.Counter: {0}", stopWatch.ElapsedMilliseconds);
                Console.ReadKey();
            }
        }
    }
