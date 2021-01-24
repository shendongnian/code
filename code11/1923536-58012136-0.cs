await dbContext.Organizations
    .AsNoTracking()
    .Select(x =>
    {
        var firstMember = x.Members.OrderBy(member => member.CreatedAt).First(member => member.Role == RoleType.Owner);
        return new OrganizationListItem
        {
            Id = x.Id,
            Name = x.Name,
            OwnerFirstName = firstMember.FirstName,
            OwnerLastName = firstMember.LastName,
            OwnerEmailAddress = firstMember.EmailAddress
        };
    })
    .ToArrayAsync();
