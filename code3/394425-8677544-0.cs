    static Person GetPerson(Dictionary<string, object> dict)
    {
        var person = new Person();
        foreach (var property in typeof(Person).GetProperties())
        {
            property.SetValue(person, dict[property.Name], null);
        }
        return person;
    }
