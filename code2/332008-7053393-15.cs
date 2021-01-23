    var member2 = context.Members.Where(m => m.FirstName == "Paul")
        .SingleOrDefault();
    var comment3 = context.Comments.Where(c => c.Message == "Good night!")
        .SingleOrDefault();
    if (member2 != null && comment3 != null)
    {
        var memberComment5 = new MemberComment { Member = member2,
                                                 Comment = comment3,
                                                 Something = 202 };
        context.MemberComments.Add(memberComment5);
        context.SaveChanges();
    }
