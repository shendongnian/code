    public static void Something(string x)
    {
        Console.WriteLine("Hello");
    }
    public static void Something(int x)
    {
        Console.WriteLine("Goodbye");
    }
    public static void Main()
    {
        object x = "A String";
        // This will choose string overload of Something() and output "Hello"
        Something((dynamic)x);
        x = 13;
        // This will choose int overload of Something() and output "Goodbye"
        Something((dynamic)x);
    }
