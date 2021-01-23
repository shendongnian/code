    class Program
    {
        static void Main(string[] args)
        {
            var b = new Foo<Guid>();
            b.Bar();
            Console.ReadLine();
        }
    }
    public class Foo<T> 
    {
        public void Bar<T>()
        {
            Console.WriteLine("Bar<T>() : " +typeof(T).Name);
        }
       public void Bar()        
        {
            Console.WriteLine("Bar() : " + typeof(T).Name);
            this.Bar<string>();
        }
    }
