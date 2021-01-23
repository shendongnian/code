    Console.WriteLine("peak");
    var peak = int.Parse(Console.ReadLine());
    Console.WriteLine("char");
    var @char = (char)Console.Read();
    //As LINQ
    var query = (from row in Enumerable.Range(0, peak * 2)
                 let count = peak - Math.Abs(peak - row)
                 let str = new string(@char, count)
                 select str
                ).ToArray(); //if you have .Net 4.0+ you don't need the .ToArray()
    Console.WriteLine(string.Join(Environment.NewLine, query));
    //As Loop
    for (int r = 1; r < peak * 2; r++)
        Console.WriteLine("{0}", new string(@char, peak - Math.Abs(peak - r)));
    Console.Read(); // hold console open 
