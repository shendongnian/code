    public class MyClass
    {
        ....
    }
    public static class MyClassExtension
    {
        public static void MyClassExtensionMethod1(this MyClass obj, string name)
        {
            if(obj == null)
            {
                // what to do here, since obj is not used anywhere in this method
            }
            Console.WriteLine(name);
        }
    }
