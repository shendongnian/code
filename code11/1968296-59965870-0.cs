    static void Main()
    {
      DateTime dt = DateTime.ParseExact("2016","yyyy", null, DateTimeStyles.None);
      Dump.DumpObject(dt);
      int i;
      bool b = int.TryParse("55", out i);
      Dump.DumpObject(i);
    }
