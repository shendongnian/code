    var maze = MazeFactory.FromPattern(Patterns.Maze3, Patterns.WallSymbol);
    var a = maze.GetElementAt(0, 1);
    var b = maze.GetElementAt(12, 0);
    var printer = new PathPrinter(ConsoleColor.Yellow, ConsoleColor.Gray, ConsoleColor.Black);
    Console.WriteLine("Maze");
    printer.Print(maze, Path.Empty);
    Console.WriteLine("A -> B");
    printer.Print(maze, new PathFinder(maze, a, b).GetPath());
    Console.WriteLine("B -> A");
    printer.Print(maze, new PathFinder(maze, b, a).GetPath());
	
