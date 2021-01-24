    CreateTable(
        "dbo.Address",
        c => new
            {
                Id = c.Int(nullable: false, identity: true),
                City = c.String(),
                MemberId = c.Int(nullable: false),
                StateId = c.Int(nullable: false),
                StreetAddress = c.String(),
                ZipCode = c.String(),
                Unit = c.String(),
            })
        .PrimaryKey(t => t.Id);
    
    CreateTable(
        "dbo.Member",
        c => new
            {
                Id = c.Int(nullable: false, identity: true),
                Active = c.Boolean(nullable: false),
                FirstName = c.String(),
                LastName = c.String(),
            })
        .PrimaryKey(t => t.Id);
