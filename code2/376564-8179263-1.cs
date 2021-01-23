    public static class Slug {
      public static string Generate(string phrase, int maxLength = 50)
    }
    //Example of call:
    var phrase = "Freech Alpes are the surfer's best spot"
    var result = Slug.Generate(phrase);
