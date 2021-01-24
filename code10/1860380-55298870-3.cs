      // Possible Suits
      string[] suits = new string[] { "Hearts", "Diamonds", "Spades", "Clubs" };
      // Possible Values: 3 groups combined
      string[] values = new string[] { "Ace" }                     // Ace
        .Concat(Enumerable.Range(2, 9).Select(c => c.ToString()))  // 2..10
        .Concat(new string[] { "Jack", "Queen", "King" })          // Jack, Queen, King
        .ToArray();
      // For each combination of Suit and value ...
      for (int suitIndex = 0; suitIndex < suits.Length; ++suitIndex)
        for (int valueIndex = 0; valueIndex < values.Length; ++valueIndex) {
          // ... we creare a card and add it to deck
          Card card = new Card() {
            Suite = suitIndex + 1,  // + 1 - since arrays are zero based
            Value = valueIndex + 1,
            cardString = $"{values[valueIndex]} of {suits[suitIndex]}"
          };
          Deck.Add(card);
          // Debug purpose only
          Console.WriteLine(card.cardString);  
        } 
