    public bool TryConvertToSystemPersonTitles(PersonTitle personTitle, out SystemPersonTitles result)
    {
        string name = PersonTitle.Mr.ToString();
        SystemPersonTitles converted;
        return Enum.TryParse(name, out result);
    }
    
