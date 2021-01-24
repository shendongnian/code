static void Main(string[] args)
{
    static string RequestInput(string variableName)
    {
        Console.WriteLine($"{variableName}:");
        return Console.ReadLine();
    }
    
    Console.WriteLine("please enter the values of:");
    var a = double.Parse(RequestInput("a"));
    var b = double.Parse(RequestInput("b"));
    var c = double.Parse(RequestInput("c"));
    
}
