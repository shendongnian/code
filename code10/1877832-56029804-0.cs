    db.CreateTable<DocumentDefinition>();
    db.CreateTable<PublishHistory>();
    
    db.Save(new PublishHistory {
        RequestedBy = "RequestedBy",
        RequestedAt = DateTime.UtcNow,
        EffectiveDate = DateTimeOffset.UtcNow,
        DocumentDefinition = new DocumentDefinition {
            LegalDocType = "LegalDocType",
            LegalDocSubType = "LegalDocSubType",
            DisplayTitle = "DisplayTitle",
            EntityName = "EntityName",
            EntityUrl = "EntityUrl",
            IsActive = true,
        }
    }, references: true);
