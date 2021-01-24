    public class Test
    {
        public const string Message = "Hello World";
    }
    // When the c# code containing the Main() method is compiled, 
    // it replaces Test.Message with "Hello World".
    static void Main()
    {
        Console.WriteLine(Test.Message);
    }
