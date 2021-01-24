    using System.Collections.Generics;
    public class Profile
    {
      public string Name { get; set; }
      public string Ethnicity { get; set; }
      public string Language { get; set; }
      public Profile(string name, string ethnicity, string language)
      {
        Name = name;
        Ethnicity = ethnicity;
        Language = language;
      }
    }
    var profiles = new List<Profile>();
    profiles.Add(new Profile("Joel", "Asian", "English"));
    profiles.Add(new Profile("Sean", "Asian", "English"));
    foreach ( var item in profiles )
    {
      Console.WriteLine("Name: " + item.Name);
      Console.WriteLine("Ethnicity: " + item.Ethnicity);
      Console.WriteLine("Language: " + item.Language);
      Console.WriteLine();
    }
