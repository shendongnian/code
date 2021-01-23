    class Program
    {
        static void Main(string[] args)
        {
            var foo = new Foo()
            foo.Calc("Foo");
        }   
    }
    
    public abstract class Base
    {
        protected Func<string, int> CalcFunction;
    
        public void Calc(string str)
        {
            Console.WriteLine(CalcFunction(str));
        }
    }
    
    public class Foo : Base
    {
        public Foo() 
        {
            this.CalcFunction = s => { return s.Length; };
        }
    }
