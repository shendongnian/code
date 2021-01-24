    var p = new PersonalDetails();
    
    var properties = p.GetType()
                      .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                      .Where(x => x.GetValue(p) != null)
                      .ToList();
