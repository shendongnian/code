    class Program
    {
        
        static void Main(string[] args)
        {
            // use a instance of a class to write
            NewClass myNewClass = new NewClass();
            myNewClass.WriteOutPut();
            // use a static class
            NewClass2.WriteOutPut();
            // finally read back so that they we can see what was ouputted
            Console.ReadLine();
        }
        
    }
    /// <summary>
    /// this is an instance class
    /// </summary>
    public class NewClass
    {
        public void WriteOutPut()
        {
            Console.WriteLine("hello");
        }
    }
    /// <summary>
    /// this is a static class
    /// </summary>
    public static class NewClass2
    {
        public static void WriteOutPut()
        {
            Console.WriteLine("hello");
        }
    }
