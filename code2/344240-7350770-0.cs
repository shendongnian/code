    private static void ShrinkFile(string file)
    {
      using(var sr = new StreamReader(file))
      {
        for (int i = 0; i < 9; i++) // throw away the first 10 lines
        {
            sr.ReadLine();
        }
        // false here means to overwrite existing file.
        using (StreamWriter sw = new StreamWriter(file, false))
        {
          sw.Write(sr.ReadToEnd());
        }
      }
    }
