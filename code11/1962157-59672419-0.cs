    HashSet<string> list1 = new HashSet<string>() { "ABC", "CDE" };
    HashSet<string> list2 = new HashSet<string>() { "ABC" };
    bool IsProperSubsetOf = list1.IsProperSubsetOf(list2);
    bool IsProperSupersetOf = list1.IsProperSupersetOf(list2);
    bool IsSubsetOf = list1.IsSubsetOf(list2);
    bool IsSupersetOf = list1.IsSupersetOf(list2);
    bool SetEquals = list1.SetEquals(list2);
