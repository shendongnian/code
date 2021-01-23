    public bool TryConvertToSystemPersonTitles(
        PersonTitle personTitle, out SystemPersonTitles result)
    {
        return Enum.TryParse(personTitle.ToString(), out result);
    }
    
