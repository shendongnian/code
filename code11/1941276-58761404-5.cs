    public class Profile
    {
      public string Name { get; set; }
      public Ethnicity Ethnicity { get; set; }
      public Language Language { get; set; }
      public Profile(string name, Ethnicity ethnicity, Language language)
      {
        Name = name;
        Ethnicity = ethnicity;
        Language = language;
      }
    }
