    await dbContext.Organizations
        .AsNoTracking()
        .Select(x => new OrganizationListItem
            {
                Id = x.Id,
                Name = x.Name,
                OwnerFirstName = x.Members.FirstOrDefault(member => member.Role == RoleType.Owner).FirstName,
                OwnerLastName = x.Members.FirstOrDefault(member => member.Role == RoleType.Owner)).LastName,
                OwnerEmailAddress = x.Members.FirstOrDefault(member => member.Role == RoleType.Owner)).EmailAddress
            })
        .ToArrayAsync();
