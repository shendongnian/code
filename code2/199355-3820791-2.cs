    public bool HasPermission(ref bool? field, bool defaultValue)
    {
        if (IsC2User())
        {
            return true;
        }
        if (field == null)  //lazy loading a bool? overkill?  :)
        {
            field = defaultValue;
        }
        return field;
    }
    //usage
    public bool HasBia
    {
        get 
        {
            return HasPermission(ref _hasBia, _excludes.HasBia);
        }
    }
