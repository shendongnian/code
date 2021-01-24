    var p = new PersonalDetails();
    
    var properties = p.GetType()
                      .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                      .Where(x => x.GetValue(p) != null && !x.GetMethod.IsPrivate)
                      .ToList();
