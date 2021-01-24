    var p = new PersonalDetails();
    
    var properties = p.GetType()
                      .GetProperties(BindingFlags.Public)
                      .Where(x => x.GetValue(p) != null);
