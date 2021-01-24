    private static void MirrorObject(object object1, object object2)
    {
        var sourceAccessor = ObjectAccessor.Create(object1);
        var targetAccessor = ObjectAccessor.Create(object2);
        var access = TypeAccessor.Create(object1.GetType());
        var members = access.GetMembers();
        foreach (var member in members)
        {
            if (member.Type.IsGenericType && (member.Type.GetGenericTypeDefinition() == typeof(IList<>)))
            {
                var list1 = (IList)sourceAccessor[member.Name];
                var list2 = (IList)targetAccessor[member.Name];
                if (list1.Count != list2.Count)
                {
                    throw new ArgumentException("Lists need to be of the same length.");
                }
                for (var i = 0; i < list1.Count; ++i)
                {
                    MirrorObject(list1[i], list2[i]);
                }
            }
            else
            {
                targetAccessor[member.Name] = sourceAccessor[member.Name];
            }
        }
    }
