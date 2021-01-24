    List<Tuple<String, Char>> Splitter(string msg, char[] chars) {
      var offset = 0;
      var splitChars = new HashSet<char>(chars); 
      var splits = new List<Tuple<String, Char>>();
      for(var idx = 0; idx < msg.Length; idx++) {
        if (splitChars.Contains(msg[idx])) {
          var split = Tuple.Create(msg.Substring(offset, idx - offset), msg[idx]);
          splits.Add(split);
          offset = idx + 1;
        } 
      }
      return splits;
    }
    string myMessage = "Apple|Car,Plane-Truck";
    var splits = Splitter(myMessage, new [] {'|', ',', '-'});
    foreach (string piece in splits)
    {
        Console.WriteLine("word: {0}, split by: {1}", piece.Item1, piece.Item2);
    }
