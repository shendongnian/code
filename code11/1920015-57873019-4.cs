    Console.WriteLine(string.Join(Environment.NewLine, 
      Coordinates(new Point(10, 10), new Point(5, 3))));
    Console.WriteLine();
    Console.WriteLine(string.Join(Environment.NewLine, 
      Coordinates(new Point(5, 3), new Point(10, 10))));
    Console.WriteLine();
    Console.WriteLine(string.Join(Environment.NewLine, 
      Coordinates(new Point(10, 10), new Point(5, 3), false)));
    Console.WriteLine();
    Console.WriteLine(string.Join(Environment.NewLine, 
      Coordinates(new Point(5, 3), new Point(10, 10), false)));
