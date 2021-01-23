    Y y = new Y();
    X x = y;
    Object o = y;
    Console.WriteLine(y.ToString()); // Shows "Hi, I'm Y, Hi, I'm X";
    Console.WriteLine(x.ToString()); // Shows "Hi, I'm Y, Hi, I'm X";
    Console.WriteLine(o.ToString()); // Calls object.ToString; shows just "Y"
