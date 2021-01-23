    List<String> concat = new List<String>();
    foreach (var result in results)
    {
        if (result.Foo.Count() == 3) // has three options?
        {
            List<String> vals = new List<string>();
            vals.AddRange(new[]{ result.ID.ToString(), result.Foo.ElementAt(0).Name });
            foreach (var foo in result.Foo)
                vals.Add(String.Format("{0} {1}", foo.Subject, foo.Marks));
            concat.Add(String.Join(",", vals.ToArray()));
        }
    }
