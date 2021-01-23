    ...
    string line;   
    while ((line = reader.ReadLine()) != null)
    {
        string proxy = line.Split(':').GetValue(0).ToString();
        ...
    });
