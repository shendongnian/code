    var result = sortCollection(p => p.ID, myMembers);
    public static IEnumerable<Member> sortCollection(Func<Member, object> keySelector, List<Member> myCollection)
    {
        return myCollection.OrderBy(keySelector);
    }
