    dbContext.Organizations.AsNoTracking()
        .Select(x => new
        {
            Id = x.Organization.Id,
            Name = x.Organization.Name,
            Owner = x.Members
                .Where(member => member.Role == RoleType.Owner)
                .OrderBy(member => member.CreatedAt)
                .Select(member => new OwnerInfo // the new class
                 {
                     FirstName = member.FirstName,
                     LastName = member.LastName,
                     EmailAddress = member.EmailAddress
                 })
                .FirstOrDefault()
        })
