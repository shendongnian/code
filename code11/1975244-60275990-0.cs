    class Program
    {
        static void Main(string[] args)
        {
            var class0 = new ClassZero();
            var class1 = new ClassOne();
            var class2 = new ClassTwo();
            var class3 = new ClassWithoutHello();
            class2.DynamicCall(class0);
            class2.DynamicCall(class3);
            Console.ReadLine();
        }
    }
    public class ClassZero
    {
        public void Hello()
        {
            Console.WriteLine("say hello from Class Zero");
        }
    }
    public class ClassOne
    {
        public void Hello()
        {
            Console.WriteLine("say hello from Class One");
        }
    }
    public class ClassWithoutHello
    {
    }
    public class ClassTwo
    {
        public void DynamicCall(dynamic input)
        {
            Console.WriteLine("calling input from Class Two");
            if ((input is ClassZero) || (input is ClassOne))
            {
                input.Hello();
            }
            else
            {
                Console.WriteLine("this type does NOT support hello method");
            }
        }
    }
