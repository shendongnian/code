    var results = new List<DateTime>();
    var errors = new List<string>();
    foreach (string value in values)
    {
        if (DateTime.TryParseExact(value, formats, culture, out var result))
        {
            results.Add(result);
        }
        else
        {
            errors.Add(value);
        }
    }
    return (results, errors);
