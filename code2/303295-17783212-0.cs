    using (var output = new StreamWriter("D:\\TMP\\output"))
    {
      foreach (var file in Directory.GetFiles("D:\\TMP", "*.*"))
      {
        using (var input = new StreamReader(file))
        {
          output.WriteLine(input.ReadToEnd());
        }
      }
    }
