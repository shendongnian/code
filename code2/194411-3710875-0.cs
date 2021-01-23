    // using Fredrik Mörk's approach
    Array.ForEach(query, x =>
        x.SomePropertyName = string.Join("_", x.SomePropertyName.Split(unwanted)));
    // using Regex
    Array.ForEach(query, x => x.SomePropertyName =
        Regex.Replace(x.SomePropertyName, "[XYZ]", "_", RegexOptions.IgnoreCase));
