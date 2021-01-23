    string title = "AJAX, JSON & HTML5! The future of web?";
    title = Regex.Replace(title, @"&amp;|&", "-");
    StringBuilder builder = new StringBuilder();
    for (int i = 0; i < title.Length; i++)
    {
        if (char.IsLetter(title[i]) || char.IsDigit(title[i]))
            builder.Append(title[i]);
        else
            builder.Append('-');
    }
    string result = builder.ToString().ToLower();
    result = Regex.Replace(result, "-+", "-");
