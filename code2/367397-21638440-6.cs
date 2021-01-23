    CreateTable(
        "dbo.LogEmailAddressStats",
        c => new
            {
                Id = c.Int(nullable: false, identity: true),
                EmailAddress = c.String(),
            })
        .PrimaryKey(t => t.Id);
          
    CreateTable(
        "dbo.LogEmailAddressStatsFails",
        c => new
            {
                Id = c.Int(nullable: false), // EF missed to set identity: true!!
                Timestamp = c.DateTime(nullable: false),
            })
        .PrimaryKey(t => t.Id)
        .ForeignKey("dbo.LogEmailAddressStats", t => t.Id)
        .Index(t => t.Id);
