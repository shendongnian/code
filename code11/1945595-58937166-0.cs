    string NumberLines;
    var largest = int.MinValue;
    var smallest = int.MaxValue;
    var count = 0;
    var total = 0;
    using(var NumbersFile = new System.IO.StreamReader(@"c:\Numbers.txt"))
    {
      while ((NumberLines = NumbersFile.ReadLine()) != null)
      {
        var value = int.Parse(NumberLines);
        count++;
        largest = Math.Max(largest,value);
        smallest = Math.Min(smallest,value);
        total += value;
      }
    }
    var average = total/count;
