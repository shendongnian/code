    public static string CaptalizeFirstLetter(this string data)
    {
        var chars = data.ToCharArray();
            
        // Find the Index of the first letter
        var charac = data.First(char.IsLetter);
        var i = data.IndexOf(charac);
            
        // capitalize that letter
        chars[i] = char.ToUpper(chars[i]);
    
        return new string(chars);
    }
