    private static void ConvertToLowerCase(JArray jArray)
    {
        foreach (var item in jArray.Children())
        {
            foreach (var property in item.Children<JProperty>().ToList())
            {
                property.Replace(new JProperty(property.Name.ToLower(), property.Value));
            }
        }
    }
