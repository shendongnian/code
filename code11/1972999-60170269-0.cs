    private static void ToLowerCase(JArray jsonObject)
    {
        foreach (var item in jsonObject.Children())
        {
            foreach (var property in item.Children<JProperty>().ToList())
            {
                property.Replace(new JProperty(property.Name.ToLower(), property.Value));
            }
        }
    }
