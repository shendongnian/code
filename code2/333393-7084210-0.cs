    foreach (CustomProperty prop in requirementTemplate.AttributesCustomList)
    {
        if (prop.Name == property && Enum.IsDefined(typeof(LevelEnum), prop.Value))
        {
            return (LevelEnum)Enum.Parse(typeof(LevelEnum), prop.Value.ToString());
        }
    }
