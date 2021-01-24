c#
// All this just to get NHibernate to map ICollection as "Set" by default?
mapper.IsSet((memberInfo, b1) =>
{
    IEnumerable<Type> typeDefs;
    Type memberType = memberInfo.GetPropertyOrFieldType();
    if (memberType.IsGenericType)
    {
        typeDefs = memberType.GetGenericInterfaceTypeDefinitions();
        if(typeDefs.Contains(typeof(ISet<>)) || typeDefs.Contains(typeof(ICollection<>)))
        {
            return true;
        }
    }
    const BindingFlags defaultBinding = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;
    var fieldInfo = (from ps in PropertyToField.DefaultStrategies.Values
        let fi = memberInfo.DeclaringType.GetField(ps.GetFieldName(memberInfo.Name), defaultBinding)
        where fi != null
        select fi).FirstOrDefault();
    if (fieldInfo != null)
    {
        memberType = fieldInfo.GetPropertyOrFieldType();
        if (memberType.IsGenericType)
        {
            typeDefs = memberType.GetGenericInterfaceTypeDefinitions();
            if (typeDefs.Contains(typeof(ISet<>)) || typeDefs.Contains(typeof(ICollection<>)))
                return true;
        }
    }
    return false;
});
This is near-copypasta and uses code from NHibernate and its included [PropertyToField](https://github.com/nhibernate/nhibernate-core/blob/master/src/NHibernate/Mapping/ByCode/PropertyToField.cs) utility class. I mostly understand it, but it's just... verbose... seems like there should be a better option. Again, am I missing a simple hook somewhere?
