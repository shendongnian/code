    var member1 = context.Members.Where(m => m.FirstName == "Pete")
        .SingleOrDefault();
    if (member1 != null)
    {
        var comment3 = new Comment { Message = "Good night!" };
        var memberComment3 = new MemberComment { Member = member1,
                                                 Comment = comment3,
                                                 Something = 103 };
        context.MemberComments.Add(memberComment3); // will also add comment3
        context.SaveChanges();
    }
