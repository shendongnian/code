    var inputs = new[]
    {
        "TM000013452S20548",
        "PB000013452S3DVSF",
    };
    foreach (var inp in inputs)
    {
        if (TryExtractFirstNumber(inp, out var result))
        {
            Debug.WriteLine(result);
        }
    }
