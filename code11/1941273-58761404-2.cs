    Dictionary<string, object> profile = new Dictionary<string, object>();
    profile.Add("Names", new string[] { "Joel", "Sean" });
    profile.Add("Ethnicity", "Asian");
    profile.Add("Language", "English");
    var names = (string[])profile["Names"];
    for ( int i = 0; i < names.Length; i++ )
    {
      Console.WriteLine($"Name: {names[i]}");
    }
    Console.WriteLine("Ethnicity - " + profile["Ethnicity"]);
    Console.WriteLine("Language - " + profile["Language"]);
