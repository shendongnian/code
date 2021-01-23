    public static void SayHello(string name = "John Doe", int age = 30)
    {
      Console.WriteLine("Hello {0}, I see you're {1} years old.", name, age);
    }
    static void Main(string[] args)
    {
      SayHello(age:42);
    }
