    static string GetName(string nameEntry)
    {
        if(string.IsNullOrWhiteSpace(nameEntry)) // assuming .NET 4
            return string.Empty; // or throw error. Your choice
        var nameParts = nameEntry.Split(new[] { ' ' }, 
                                             StringSplitOptions.RemoveEmptyEntries);
        if(nameParts.Length == 1)
            return nameParts.First();
        var fullName = string.Format("{0} {1}", nameParts.First(), nameParts.Last());
        return fullName;
    }
