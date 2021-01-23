    class Program
    {
        static void Main(string[] args)
        {
            System.Reflection.Assembly assy = System.Reflection.Assembly.LoadFile(args[0]);
            Type class1 = assy.GetType("Lib.Class1");
            System.Reflection.MethodInfo myMethod = class1.GetMethod("MyMethod");
            Console.WriteLine(myMethod.Invoke(null, new object[] {"This is a string"}).ToString());
            Console.ReadLine();
        }
    }
