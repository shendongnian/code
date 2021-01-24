    var p1 = new Point(1, 2);
    var p2 = new Point(3, 4);
    var line = new Line(p1, p2);
    MSTSpine.Add(line);
    Console.WriteLine(MSTSpine[0].Start.X);
    Console.WriteLine(MSTSpine[0]); // Prints:  (1, 2) - (3, 4)
