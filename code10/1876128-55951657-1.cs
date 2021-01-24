    public class SomeObject
    {
        string name;
        public SomeObject(string name)
        {
            this.name = name;
        }
        public void Method(Random random)
        {
            Console.WriteLine($"{name}:  {random.Next(1, 101)}");
        }
    }
