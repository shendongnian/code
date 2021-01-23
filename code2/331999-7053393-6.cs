    var comment2 = context.Comments.Where(c => c.Message == "Good evening!")
        .SingleOrDefault();
    if (comment2 != null)
    {
        var member2 = new Member { FirstName = "Paul" };
        var memberComment4 = new MemberComment { Member = member2,
                                                 Comment = comment2,
                                                 Something = 201 };
        context.MemberComments.Add(memberComment4);
        context.SaveChanges();
    }
