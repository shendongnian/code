static void Main(string[] args)
{
    //Returns the path to the file
    Console.WriteLine(args[0]); 
    // Index 1 returns file path, while index 0 returns the executable path
    Console.WriteLine(Environment.GetCommandLineArgs()[1].ToString()); 
}
