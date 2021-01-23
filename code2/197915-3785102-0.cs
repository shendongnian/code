    public bool HasMatchingWord(string left, string right) { 
      var hashSet = new HashSet<string>(
        left.Split(" ", StringSplitOptions.RemoveEmptyEntries)); 
      return right
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Any(x => hashSet.Contains(x));
    }
