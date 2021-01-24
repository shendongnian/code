    using System.Linq;
    ...
    var demo = string.Join(Environment.NewLine, Enumerable
      .Range(1, 15)
      .Select(n => $"{n,2} -> {Solution(n),3}"));
    Console.Write(demo);
