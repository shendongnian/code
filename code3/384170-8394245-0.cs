    if (Regex.IsMatch(password, @"\d+", RegexOptions.ECMAScript))
        score++;
    if (Regex.IsMatch(password, @"[a-z]", RegexOptions.ECMAScript) &&
        Regex.IsMatch(password, @"[A-Z]", RegexOptions.ECMAScript))
        score++;
    if (Regex.IsMatch(password, @".[!@#\$%\^&\*\?_~\-£\(\)]", RegexOptions.ECMAScript))
        score++; 
