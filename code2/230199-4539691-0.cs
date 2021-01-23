    public static MemberInfo[] SortMembers(IEnumerable<MemberInfo> members)
    {
        return members.OrderBy(m => m.GetType().Name)
                      .ToArray();
    }
