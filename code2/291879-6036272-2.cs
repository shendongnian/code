    /// <summary>
    /// Get a list of properties that are enum types
    /// </summary>
    /// <returns>Enum property names</returns>
    public string[] GetVisiblePropertyNames()
    {
        MemberInfo[] members = GetType().FindMembers(MemberTypes.Property, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance, new MemberFilter(SearchForVisibleProperties), null);
        List<string> retList = new List<string>();
        foreach (MemberInfo nextMember in members)
        {
            PropertyInfo nextProp = nextMember as PropertyInfo;
            if (nextProp.GetType().IsEnum)
                retList.Add(nextProp.Name);
        }
        return retList.ToArray();
    }
