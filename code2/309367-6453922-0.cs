    var text = @"1: A C D
    4: A B
    5: D F
    7: A E
    9: B C";
    
    var lookup = text
      .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
      .Select(
        line => new {
          Number = Int32.Parse(line.Split(':').First()),
          Letters = line.Split(':').Skip(1).First().Split(
            new[] {' '}, StringSplitOptions.RemoveEmptyEntries
          )
        }
      )
      .SelectMany(x => x.Letters, (x, letter) => new { x.Number, Letter = letter })
      .OrderBy(x => x.Letter)
      .ToLookup(x => x.Letter, x => x.Number);
      
    foreach (var item in lookup)
      Console.WriteLine(item.Key + ": " + String.Join(" ", item.ToArray()));
