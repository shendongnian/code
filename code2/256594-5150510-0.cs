    public enum SomeEnum
    {
        V1,
        V2
    }
    class Program
    {
        static void Main(string[] args)
        {
            var values = Enum.GetValues(typeof (SomeEnum));
            Console.WriteLine("Count: {0}", values.Length);
            foreach (SomeEnum e in values)
            {
                Console.WriteLine(e);
            }
        }
    }
