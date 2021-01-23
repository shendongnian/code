    public IEnumerable<string> GenerateStrings()
    {
        foreach(string character in Alphabeth())
        {
          yield return character;
        }
        foreach (string prefix in GenerateStrings())
        {
          foreach(string suffix in Alphabeth())
          {
            yield return prefix + suffix;
          }
        }
    }
    public IEnumerable<string> Alphabeth()
    {
        for(int i = 0; i < 26; i++)
        {
          yield return ((char)('A' + i)).ToString();
        }
    }
