    public static ISet<string> CombinationsAndPermutations(string input) {
        if (string.IsNullOrWhiteSpace(input)) {
            return new HashSet<string>();
        }
        if (input.Length == 1) {
            return new HashSet<string> { string.Empty, input };
        }
        ISet<string> result = new HashSet<string>();
        for (int i=0; i<input.Length; i++) {
            char letter = input[i];
            string remainingBefore = input.Substring(0, i);
            string remainingAfter = input.Substring(i+1);
            string remaining = remainingBefore + remainingAfter;
            ISet<string> subResult = CombinationsAndPermutations(remaining);
            
            foreach (string subStr in subResult) {
                result.Add(subStr);
                result.Add(letter + subStr);
            }
        }
        return result;
    }
