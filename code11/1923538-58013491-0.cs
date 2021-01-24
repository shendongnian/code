    dbContext.Organizations.AsNoTracking()
        // intermediate projection
        .Select(x => new
        {
            Organization = x,
            Owner = x.Members
                .Where(member => member.Role == RoleType.Owner)
                .OrderBy(member => member.CreatedAt)
                .FirstOrDefault()
        })
        // final projection
        .Select(x => new OrganizationListItem
        {
            Id = x.Organization.Id,
            Name = x.Organization.Name,
            OwnerFirstName = Owner.FirstName,
            OwnerLastName = Owner.LastName,
            OwnerEmailAddress = Owner.EmailAddress
        })
