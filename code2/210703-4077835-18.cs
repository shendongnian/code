    public IEnumerable<string> GenerateStrings()
    {
        foreach(string character in Alphabet())
        {
          yield return character;
        }
        foreach (string prefix in GenerateStrings())
        {
          foreach(string suffix in Alphabet())
          {
            yield return prefix + suffix;
          }
        }
    }
    public IEnumerable<string> Alphabet()
    {
        for(int i = 0; i < 26; i++)
        {
          yield return ((char)('A' + i)).ToString();
        }
    }
