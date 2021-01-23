    class Program
    {
        public static void Main()
        {
            var myInt = new MyGeneric<int>();
            myInt.InstanceMethod();
            MyGeneric<int>.StaticMethod();
    
            MyGeneric<long>.StaticMethod();
            var myLong = new MyGeneric<long>();
            myLong.InstanceMethod();
    
            Console.ReadLine();
        }
    }
    
    public class MyGeneric<T>
    {
        static MyGeneric()
        {
            Console.WriteLine("Static constructor: {0}", typeof(T).Name);
        }
    
        public static void StaticMethod()
        {
            Console.WriteLine("Static method: {0}", typeof(T).Name);
        }
    
        public void InstanceMethod()
        {
            Console.WriteLine("Instance method: {0}", typeof(T).Name);
        }
    }
