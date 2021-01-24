    public static string RenameProperties(string json, Dictionary<string, string> nameMappings)
    {
        JContainer token = (JContainer)JToken.Parse(json);
        // Note: We need to process the descendants in reverse order here
        // to ensure we replace child properties before their respective parents
        foreach (JProperty prop in token.Descendants().OfType<JProperty>().Reverse().ToList())
        {
            if (nameMappings.TryGetValue(prop.Name, out string newName))
            {
                prop.Replace(new JProperty(newName, prop.Value));
            }
        }
        return token.ToString();
    }
