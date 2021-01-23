    public static int getNumberOfMatches(List<int> userGuesses, List<int> machineGuesses) {
        // Determine list equality.
        bool matchedAll = true;
        for (int i = 0; i < userGuesses.Count; i++) {
            if (userGuesses[i] != machineGuesses[i]) {
                matchedAll = false;
                break;
            }
        }
        // The lists were equal; return numberOfGuesses + 1 [which equals 4 in this case].
        if (matchedAll) {
            return userGuesses.Count + 1;
        }
        // Remove all matches from machineGuesses.
        foreach (int userGuess in userGuesses) {
            if (machineGuesses.Contains(userGuess)) {
                machineGuesses.Remove(userGuess);
            }
        }
        // Determine number of matches made.
        return userGuesses.Count - machineGuesses.Count;
    }
