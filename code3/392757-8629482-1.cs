    static string GetName(string nameEntry)
    {
        // assuming .NET 4, or use string.IsNullOrEmpty(), 
        //    as we are protected later from white space-only text
        if(string.IsNullOrWhiteSpace(nameEntry))
            return string.Empty; // Or throw error. Your choice
        var nameParts = nameEntry.Split(new[] { ' ' }, 
                                            StringSplitOptions.RemoveEmptyEntries);
        if(!nameParts.Any()) return string.Empty(); // Or throw error. Your choice
        
        if(nameParts.Length == 1)
            return nameParts.First();
        var fullName = string.Format("{0} {1}", nameParts.First(), nameParts.Last());
        return fullName;
    }
