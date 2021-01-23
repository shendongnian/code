    var memberComment5 = context.MemberComments
        .Where(mc => mc.Member.FirstName == "Paul"
            && mc.Comment.Message == "Good night!")
        .SingleOrDefault();
    if (memberComment5 != null)
    {
        context.MemberComments.Remove(memberComment5);
        context.SaveChanges();
    }
