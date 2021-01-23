    public bool HasPermission(ref bool? field, Func<bool> getDefaultValue)
    {
        if (IsC2User())
        {
            return true;
        }
        return field ?? getDefaultValue();
    }
    //usage
    public bool HasTeachAndTest
    {
        get
        {
            return HasPermission(ref _hasTeachAndTest, () => _excludes.HasTeachAndTest);
        }
    }
