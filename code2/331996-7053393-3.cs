    var membersWithComments = context.Members
        .Where(m => m.LastName == "Smith")
        .Select(m => new
        {
            Member = m,
            Comments = m.MemberComments.Select(mc => mc.Comment)
        })
        .ToList();
