    class Program
    {
        static void Main(string[] args)
        {
            var param = new Container<int>(){ Name = "Age", Value =  60};
            Test(param);
        }
        public static void Test<TType>(Container<TType> container)
        {
           
            Console.Write(string.Format("{0} = {1}", container.Name, container.Value));
            Console.ReadLine();
            
        }
    }
    public class Container<TType>
    {
        public string Name { get; set; }
        public TType Value { get; set; }
    }
