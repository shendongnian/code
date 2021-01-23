    IEnumerable<Father> fathers;
    using (var db = GetDataContext())
    {
      // Assume a Father as a field called Sons of type IEnumerable<Son>
      fathers = db.Fathers.ToList();
    }
    foreach (var father in fathers)
    {
      // This will get the exception you got
      Console.WriteLine(father.Sons.FirstOrDefault());
    }
