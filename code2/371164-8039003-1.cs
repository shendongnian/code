    public class MyClass :
        MarshalByRefObject
    {
        public int MyValue;
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new MyClass();
            
            // This will give you warning CS1690: Accessing a member on 'MyValue' may cause a runtime exception because it is a field of a marshal-by-reference class
            Console.WriteLine(obj.MyValue.ToString());
        }
    }
