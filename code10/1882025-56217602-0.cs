class Program
{
    private static void Print((int Id, string Name) args)
    {
        Console.WriteLine($"ID = {args.Id.ToString()}");
        Console.WriteLine($"Name = {args.Name}");
    }
    public static void Main(string[] args)
    {
        Print((20, "John"));
        Console.ReadKey();
    }
}
