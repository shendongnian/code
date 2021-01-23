    public class Foo
    {
        public Foo([Optional, DefaultParameterValue(5)] int optional)
        {
            Console.WriteLine("Constructed");
        }
    }
 
