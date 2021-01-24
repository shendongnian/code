public class Light
    {
        private readonly int innervar;
        
        public Light(int _innervar)
        {
            innervar = _innervar;
        }
        public int usefulMethod(int param)
        {
            int tmp;
            tmp = innervar * innervar / innervar + innervar * param;
            return tmp;
        }
    }
then the same one but with useless functions and parameter everywhere.
class Heavy
    {
        private int innervar;
        private string uselessString;
        private float uselessFloat;
        public Heavy(int _innervar)
        {
            innervar = _innervar;
        }
        public Heavy(string _uselessString)
        {
            uselessString = _uselessString;
        }
        public Heavy(float _uselessFloat)
        {
            uselessFloat = _uselessFloat;
        }
        public int usefulMethod(int param)
        {
            int tmp;
            tmp = innervar * innervar / innervar + innervar * param;
            return tmp;
        }
        public int usefulMethod(float param)
        {
            int tmp;
            tmp = innervar * innervar / innervar + innervar * (int)param;
            return tmp;
        }
        public int usefulMethod(double param)
        {
            int tmp;
            tmp = innervar * innervar / innervar + innervar * (int)param;
            return tmp;
        }
        public int uselessMethod1()
        {
            int tmp;
            tmp = innervar * innervar / innervar + innervar;
            return tmp;
        }
        public int uselessMethod2()
        {
            int tmp;
            tmp = innervar * innervar / innervar + innervar;
            return tmp;
        }
        public int uselessMethod3()
        {
            int tmp;
            tmp = innervar * innervar / innervar + innervar;
            return tmp;
        }
        public int uselessMethod4()
        {
            int tmp;
            tmp = uselessprivate1(innervar);
            return tmp;
        }
        private int uselessprivate1(int tmp)
        {
            
            tmp = innervar * innervar / innervar + innervar;
            return tmp;
        }
        private int uselessprivate2(int tmp)
        {
            tmp = innervar * innervar / innervar + innervar;
            return tmp;
        }
    }
And here is the main test code that will call the 2 different classes:
class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(500);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 1; i < 100; i++)
            {
                var light = new Light(i);
                for (int y = 1; y < 1000000; y++)
                {
                    light.usefulMethod(y);
                }
            }
            
            watch.Stop();
            Console.WriteLine("Light: " + watch.ElapsedMilliseconds);
            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 1; i < 100; i++)
            {
                var heavy = new Heavy(i);
                for (int y = 1; y < 1000000; y++)
                {
                    heavy.usefulMethod(y);
                }
            }
            watch2.Stop();
            Console.WriteLine("Heavy: " + watch2.ElapsedMilliseconds);
            var watch3 = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 1; i < 1000000; i++)
            {
                var light = new Light(i);
                for (int y = 1; y < 100; y++)
                {
                    light.usefulMethod(y);
                }
            }
            watch3.Stop();
            Console.WriteLine("Light: " + watch3.ElapsedMilliseconds);
            var watch4 = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 1; i < 1000000; i++)
            {
                var heavy = new Heavy(i);
                for (int y = 1; y < 100; y++)
                {
                    heavy.usefulMethod(y);
                }
            }
            watch4.Stop();
            Console.WriteLine("Heavy: " + watch4.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
And then the result that every time U run the program seem to be consistent ans quite counterintuitive. I also tried to add a sleep at the begining to avoid as much possible slow down due to the programm startup.
> Light: 2236  
> Heavy: 1608  
> Light: 1660  
> Heavy: 1537  
So in the end theses results are quite disturbing. I encourage you to try on your machine, but I'll definetly dig deeper on my side too. 
  [1]: https://www.dotnetperls.com/optimization
