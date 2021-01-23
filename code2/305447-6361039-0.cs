    bool nameIsMatch = false;
    bool typeIsMatch = false;
    foreach (string namePattern in namePatterns)
    {
        nameIsMatch = nameIsMatch || Regex.IsMatch(nameString, namePattern);
    }
    foreach (string typePattern in typePatterns)
    {
        typeIsMatch = typeIsMatch || Regex.IsMatch(typeString, typePattern);
    }
    if (nameIsMatch && typeIsMatch)
    {
        // Whatever you want to do
    }
