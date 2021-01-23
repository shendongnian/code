    IEnumerable<string> getAnimals(TextReader rdr)
    {
      using(rdr)
        for(string line = rdr.ReadLine(); line != null; line = rdr.ReadLine())
          yield return line;
    }
