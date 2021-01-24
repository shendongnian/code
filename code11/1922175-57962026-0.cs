    int occurences = 0;
    string sentence = "This is a test sentence. This sentence is test. This sentence do nothing.";
    var sentenceWords = new string(sentence.Where(c => !char.IsPunctuation(c)).ToArray()).Split(' ');
    var wordsFound = new Dictionary<string, int>();
    Console.WriteLine("Sentence = " + sentence);
    while ( true)
    {
      Console.WriteLine(Environment.NewLine);
      Console.WriteLine("Type in a censored word you wish to be counted (enter empty to end): ");
      string input = Console.ReadLine();
      if ( input == "" ) break;
      int count = sentenceWords.Count(word => word.ToLower() == input.ToLower());
      if ( count == 0 )
      {
        Console.WriteLine("Can't find \"" + input + "\".");
      }
      else
      {
        Console.WriteLine("Found " + count + " occurences of \"" + input + "\".");
        if ( !wordsFound.ContainsKey(input) )
          wordsFound.Add(input, count);
        occurences += count;
      }
    }
    Console.WriteLine(Environment.NewLine);
    Console.WriteLine("Number of total censored words occurences: " + occurences);
    foreach ( var item in wordsFound)
      Console.WriteLine("     " + item.Key + ": " + item.Value);
    Console.ReadKey();
