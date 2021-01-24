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
**Edit 2:**  
I tried the above solution by removing the possible bias.
I made sure that none of the code is ignore at compile time by using first all the functions in heavy at least once.  
Then I also only tried the method inside and not the instantation.  
there is the nex version of the main:  
var light2 = new Light(125);
var watch3 = System.Diagnostics.Stopwatch.StartNew();
for (int y = 1; y < 500000000; y++)
{
    light2.usefulMethod(y);
}
watch3.Stop();
Console.WriteLine("Light: " + watch3.ElapsedMilliseconds);
var heavy2 = new Heavy(125);
heavy2.uselessMethod1();
heavy2.uselessMethod2();
heavy2.uselessMethod3();
heavy2.uselessMethod4();
var watch4 = System.Diagnostics.Stopwatch.StartNew();
for (int y = 1; y < 500000000; y++)
{
    heavy2.usefulMethod(y);
}
watch4.Stop();
Console.WriteLine("Heavy: " + watch4.ElapsedMilliseconds);
Console.ReadKey();
And now there are the expected results:
> Light: 6603  
> Heavy: 6807  
  
**Edit 3:**  
So there is only the instanciation only test:  
for (int it = 1; it < 10; it++)
{ 
    var watch = System.Diagnostics.Stopwatch.StartNew();
    for (int i = 1; i < 50000000; i++)
    {
        var light1 = new Light(i);
    }
    watch.Stop();
    Console.WriteLine("Light " + it + ": " + watch.ElapsedMilliseconds);
    var watch2 = System.Diagnostics.Stopwatch.StartNew();
    for (int i = 1; i < 50000000; i++)
    {
        var heavy1 = new Heavy(i);
    }
    watch2.Stop();
    Console.WriteLine("Heavy " + it + ": " + watch2.ElapsedMilliseconds);
}
and there are the results, these ones seem way more constant:
> Light 1: 939  
> Heavy 1: 985  
> Light 2: 668  
> Heavy 2: 709  
> Light 3: 665  
> Heavy 3: 704  
> Light 4: 741  
> Heavy 4: 898  
> Light 5: 670  
> Heavy 5: 709  
> Light 6: 643  
> Heavy 6: 690  
> Light 7: 628  
> Heavy 7: 689  
> Light 8: 649  
> Heavy 8: 718  
> Light 9: 651  
> Heavy 9: 689  
  
**edit 4:** After decompiling the abose code, now I know that even if you don't use functions they will be compiled. In my results even without using most of `Heavy`'s methods, everything was still compilated. using [dotPekk][2] and making sure to :  
> clear the Use sources from symbol files when available checkbox on the
> Decompiler page of dotPeek options
  [1]: https://www.dotnetperls.com/optimization
  [2]: https://www.jetbrains.com/help/decompiler/dotPeek_Getting_Started.html
