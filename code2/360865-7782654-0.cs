    public int getNumberOfMatches(int[] userGuesses, int[] machineGuesses) {
      if (userGuesses.Equals(machineGuesses)) {
        // This is a more general solution, but should equal 4 in your case.
        return machineGuesses.Length + 1;
      }
    
      int matching = 0;
      foreach (int userGuess in userGuesses) {
        if (machineGuesses.Contains(userGuess) {
          matching++;
        }
      }
    
      return matching;
    }
