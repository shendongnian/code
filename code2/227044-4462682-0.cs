    ILookup<int, int> guessLookup = guess.ToLookup(i => i);
    
    int blackPlusWhite
    (
      from secretNumber in secret.GroupBy(i => i)
      let secretCount = secretNumber.Count()
      let guessCount = guessLookup[secretNumber.Key].Count()
      select Math.Min(secretCount, guessCount)
    ).Sum()
    
    int black = Enumerable.Range(0, secret.Count).Count(i => guess[i] == secret[i]);
    
    int white = blackPlusWhite - black;
