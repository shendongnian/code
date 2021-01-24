    CreateTable(
        "assets.AssetHeaderEquipment",
        c => new
            {
                AssetHeaderId = c.Guid(nullable: false),
                AssetEquipmentId = c.Guid(nullable: false),
                StartDate = c.DateTime(nullable: false),
                EndDate = c.DateTime(),
                Comment = c.String(maxLength: 255),
            })
        .PrimaryKey(t => new { t.AssetHeaderId, t.AssetEquipmentId })
        .ForeignKey("assets.AssetHeader", t => t.AssetEquipmentId)
        .ForeignKey("assets.AssetHeader", t => t.AssetHeaderId, cascadeDelete: true)
        .Index(t => t.AssetHeaderId)
        .Index(t => t.AssetEquipmentId);
    
    CreateTable(
        "assets.AssetHeader",
        c => new
            {
                Id = c.Guid(nullable: false),
            })
        .PrimaryKey(t => t.Id);
