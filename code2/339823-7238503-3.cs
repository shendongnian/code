    foreach (XElement e in person)
    {
        // Avoid getting the KeyNotFoundException
        if(!person.ContainsKey(e.Name.ToString()))
        {
            person.Add(e.Name.ToString(), "some default value");
        }
        person[e.Name.ToString()] = e.Value;
    }
    if (person["Name"] == null || person["Job"] == null || person["HairColor"] == null)
    {
        return false;
    }
    else
    {
        return true;
    }
}
