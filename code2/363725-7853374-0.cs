    public class End
    {
        public StringBuilder parameter;
        public End(StringBuilder parameter)
        {
            this.parameter = parameter;
            this.Init();
            Console.WriteLine("Inside: {0}", parameter);
        }
        public void Init()
        {
            this.parameter.Clear();
            this.parameter.Append("success");
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            StringBuilder s = new StringBuilder("failed");
            End e = new End(s);
            Console.WriteLine("After: {0}", s);
        }
    }
