    // Split either
    //   1. by space
    //   2. zero length "char" which is just after a [0..9] digit and followed by "-" or "+"
    var items = Regex
      .Split(line, @" |((?<=[0-9])(?=[+-]))")
      .Where(item => !string.IsNullOrEmpty(item)) // we don't want empty parts 
      .Skip(1)                                    // skip 1st 33
      .Select(item => double.Parse(item));        // we want double
    Console.WriteLine(string.Join(Environment.NewLine, items));
