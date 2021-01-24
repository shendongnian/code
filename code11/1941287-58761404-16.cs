    var profiles = new List<Profile>();
    profiles.Add(new Profile("Joel", Ethnicity.Asian, Language.English));
    profiles.Add(new Profile("Sean", Ethnicity.Asian, Language.English));
    foreach ( var item in profiles )
    {
      Console.WriteLine("Name: " + item.Name);
      Console.WriteLine("Ethnicity: " + item.Ethnicity);
      Console.WriteLine("Language: " + item.Language);
      Console.WriteLine();
    }
