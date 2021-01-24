    var results = new List<DateTime>();
    var errors = new List<string>();
    foreach (string value in values)
    {
        bool success = false;
        foreach (string format in formats)
        {
            if (DateTime.TryParseExact(value, format, culture, out var result))
            {
                results.Add(result);
                success = true;
                break;
            }
        }
    
        if (!success)
        {
            errors.Add(value);
        }
    }
    return (results, errors);
