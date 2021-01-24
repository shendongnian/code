    float min = 800.5F, max = 850.5F;
    
    var lines = File.ReadAllLines(usersPath);
    var separator = ";"; // Change this according to which separator you're using between your values. You only need this if you have multiple values per line
    
    foreach (var line in lines)
    {
        foreach (string word in line.Trim().Split(separator))
        {
            if ((float)Convert.ToDouble(word.Trim()) >= min && (float)Convert.ToDouble(word.Trim()) <= max)
            {
                line.Replace(word, "");
            }
        }
    }
    File.WriteAllLines(usersPath, lines);
