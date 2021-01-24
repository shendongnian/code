    var result = dbContext.Ministries.GroupJoin(
        dbContext.MemberGroup,
        ministry => ministry.Id,
        memberGroup => memberGroup.MinistryId,
        (ministry, memberGroupsOfThisMinistry) => new
        {
            Id = ministry.Id,
            Name = ministry.Name,
            MemberGroups = memberGroupsOfThisMinistry.Select(memberGroup => new
            {
                Id = memberGroup.Id,
                Name = memberGroup.Name,
                ...
            })
            .ToList(),
         });
