     var enumerable = new[] {54, 107, 24, 223, 134, 65, 36, 7342, 812, 96, 106};
     Console.WriteLine(String.Join(",",enumerable.ToArray()));
     var rangeSize = 2;
     var range = enumerable.Range((x) => x == 134, rangeSize);
     Console.WriteLine(String.Join(",",range.ToArray()));
