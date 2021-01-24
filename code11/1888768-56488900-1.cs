    float min = 800.5F, max = 850.5F;
    float currentValue;
    
    var lines = File.ReadAllLines(usersPath);
    var separator = ";"; // Change this according to which separator you're using between your values (if any)
    
    foreach (var line in lines)
    {
        foreach (string word in line.Trim().Split(separator))
        {
            if (float.TryParse(word.Trim(), out currentValue))
            {
                if (currentValue >= min && currentValue <= max)
                {
                    line.Replace(word, "");
                }
            }
        }
    }
    File.WriteAllLines(usersPath, lines);
