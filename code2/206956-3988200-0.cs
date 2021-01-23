    static void Main(string[] args)
    {
      string WelcomeMessage =
                                  @" _______ _   _______      _______          " + Environment.NewLine +
                                  @"|__   __(_) |__   __|    |__   __|         " + Environment.NewLine +
                                  @"   | |   _  ___| | __ _  ___| | ___   __   " + Environment.NewLine +
                                  @"   | |  | |/ __| |/ _` |/ __| |/ _ \ / _ \ " + Environment.NewLine +
                                  @"   | |  | | (__| | (_| | (__| | (_) |  __/ " + Environment.NewLine +
                                  @"   |_|  |_|\___|_|\__,_|\___|_|\___/ \___| ";
      List<Rectangle> list = new List<Rectangle>();
      list.Add(new Rectangle(new Point(0, 0), new Size(7, 6)));
      list.Add(new Rectangle(new Point(8, 0), new Size(2, 6)));
      list.Add(new Rectangle(new Point(10, 2), new Size(4, 4)));
      Dictionary<Rectangle, ConsoleColor> colors = new Dictionary<Rectangle, ConsoleColor>();
      colors.Add(list[0], ConsoleColor.DarkBlue);
      colors.Add(list[1], ConsoleColor.DarkRed);
      colors.Add(list[2], ConsoleColor.DarkGreen);
      Console.WriteLine(WelcomeMessage);
      
      // NOTE: you might want to save the lines in an array where you define it:
      string[] lines = WelcomeMessage.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
      for (int y = 0; y < lines.Length; y++)
      {
        string line = lines[y];
        for (int x = 0; x < line.Length; x++)
        {
          Rectangle rect = list.Where(c =>
            x >= c.X && x <= c.X + c.Width && 
            y >= c.Y && y <= c.Y + c.Height).FirstOrDefault();
          if (rect == Rectangle.Empty)
            break ; // TODO Not implemented yet           
          else
          {            
            Console.ForegroundColor = colors[rect];
            Console.Write(line[x]);
          }
        }
        Console.WriteLine();
      }
      Console.ReadKey();      
    }
