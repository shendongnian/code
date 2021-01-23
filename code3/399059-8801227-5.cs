    public Member FindPrimaryKey<T>(ClassMap<T> map)
    {
        var providersInfo = map.GetType().BaseType.GetField("providers", BindingFlags.Instance | BindingFlags.NonPublic);
        var providersValue = (MappingProviderStore) providersInfo.GetValue(map);
        var id = providersValue.Id;
        var pkMemberInfo = (Member)id.GetType().GetField("member", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(id);
        return pkMemberInfo;
    }
