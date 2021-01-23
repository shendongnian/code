    public bool HasPermission(ref bool? field, bool defaultValue)
    {
        if (IsC2User())
        {
            return true;
        }
        return field ?? defaultValue;  //lazy loading a bool? overkill.  :)
    }
    //usage
    public bool HasBia
    {
        get 
        {
            return HasPermission(ref _hasBia, _excludes.HasBia);
        }
    }
