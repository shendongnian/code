    public string ToUpperFirstLetter(string source)
    {
        if (String.IsNullOrEmpty(source))
            return String.Empty;
        // convert to char array of the string
        var letters = source.Replace(".exe", String.Empty).ToCharArray();
        // upper case the first char
        letters[0] = Char.ToUpper(letters[0], CultureInfo.CurrentCulture);
        // return the array made of the new char array
        return new string(letters);
    }
