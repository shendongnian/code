    var query = Mc.Select(m => m.Machine)
                  .Distinct()
                  .Select(m => new MyClass { Machine = m, Service = "bar" })
                  .ToArray();
    Mc.AddRange(query);
