    IEnumerable<Father> fathers;
    using (var db = GetDataContext())
    {
      var options = new System.Data.Linq.DataLoadOptions();
      options.LoadWith<Father>(f => f.Sons);
      db.LoadOptions = options;
      fathers = db.Fathers.ToList();
    }
    foreach (var father in fathers)
    {
      // This will no longer throw
      Console.WriteLine(father.Sons.FirstOrDefault());
    }
