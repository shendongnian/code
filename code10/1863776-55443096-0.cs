    public bool ChatWithMembersDoesExistYet(List<User> members)
    {
          return _hankContext.Chats
                             .Any(x => x.Members
                             .Select(y => y.Member)
                             .Select(y => y.Id)
                             .OrderByDescending(z => z)
                             .SequenceEqual(members
                                            .Select(y => y.Id).OrderByDescending(z => z)));
    }
