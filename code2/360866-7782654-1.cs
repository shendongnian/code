    public int getNumberOfMatches(int[] userGuesses, int[] machineGuesses) {
      int matching = 0;
      bool matchedAll = true;
      for (int i = 0; i < userGuesses.Length; i++) {
        if (machineGuesses.Contains(userGuesses[i])) {
          matching++;
        }
        if (machineGuesses[i] != userGuesses[i]) {
          matchedAll = false;
        }
      }
    
      if (matchedAll) {
        matching++;
      }
      return matching;
    }
