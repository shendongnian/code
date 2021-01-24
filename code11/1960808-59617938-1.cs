   JObject entries = JObject.Parse(jsonString);
   Console.WriteLine(entries["entries"][0]["2019"][0]["january"][0]["6"][0]["ingredients"][0]["kaloriar"].ToString());
**Output**
20
**Create Dictionary of Dictionary...**
You can create a recursive method to build out your `Dictionary<string, object>` items. Reason it has to be Dictionary of objects is because you have dynamic values each time you go in sub node.
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
And you can access the data you are looking for very similarly to what you wre looking for.
Console.WriteLine(JObject.Parse(JsonConvert.SerializeObject(dict))["entries"]["2019"]["january"]["6"]["Meal"]["ingredients"]["kaloriar"].ToString());
**Output**
20
In essence what you are doing is taking the array of elements and converting only elements into dictionaries for accessing the way you want.
