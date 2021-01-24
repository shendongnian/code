    public static void Main(string[] args)
    {
      switch (args[0])
      {
          case "+":
             Console.WriteLine(args.Skip(1)
                                   .Select(int.Parse)
                                   .Sum());
             break;
      ...
