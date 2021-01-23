    foreach (var pair in dictionary.ToList())
    {
        // to update the value
        dictionary[pair.Key] = "Some New Value";
        // or to change the key => remove it and add something new
        dictionary.Remove(pair.Key);
        dictionary.Add("Some New Key", pair.Value);
    }
