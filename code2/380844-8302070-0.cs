    foreach (var str in listOStrings)
    {
        foreach (var c in str)
        {
            if (Char.IsControl(c))
            {
                result.Add(c);
            }
        }
    }
