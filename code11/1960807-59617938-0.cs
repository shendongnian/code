    public static Dictionary<string, object> BuildDictionary(JObject input)
    {
        var properties = input.Properties();
        // Terminator
        if (properties.ToList().Where(x => x.Name.Equals("name")).Count() > 0)
        {
            Day thisDay = new Day()
            {
                name = input["name"].ToString(),
                ingredients = new Ingredients()
                {
                    kaloriar = input["ingredients"][0]["kaloriar"].ToString(),
                    salt = input["ingredients"][0]["salt"].ToString()
                }
            };
            return new Dictionary<string, object>() { { "Meal", thisDay } };
        }
        // Recursive
        Dictionary<string, object> obj = new Dictionary<string, object>();
        foreach (JProperty property in properties) 
        {
            foreach (var element in input[property.Name])
                obj.Add(property.Name, BuildDictionary(element as JObject));
                
        }
        return obj;
    }
**Usage in Main**
   JObject entries = JObject.Parse(jsonString);
   Dictionary<string, object> dict = BuildDictionary(entries);
**Resulting Dictionary**
{
  "entries": {
    "2019": {
      "january": {
        "6": {
          "Meal": {
            "name": "Litago",
            "ingredients": {
              "kaloriar": "20",
              "salt": "10"
            }
          }
        }
      }
    }
  }
}
