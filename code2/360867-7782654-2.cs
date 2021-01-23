    public static int getNumberOfMatches(List<int> userGuesses, List<int> machineGuesses) {
        // Determine list equality for bonus point.
        bool matchedAll = true;
        for (int i = 0; i < userGuesses.Count; i++) {
            if (userGuesses[i] != machineGuesses[i]) {
                matchedAll = false;
                break;
            }
        }
        if (matchedAll) {
            return userGuesses.Count + 1;
        }
        // Remove all matches from machineGuesses.
        foreach (int userGuess in userGuesses) {
            if (machineGuesses.Contains(userGuess)) {
                machineGuesses.Remove(userGuess);
            }
        }
        // Determine score based on number of matches made (and possibly bonus point).
        return userGuesses.Count - machineGuesses.Count + bonusPoints;
    }
