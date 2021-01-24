    modelBuilder.Entity<AssetHeader>()
        .HasMany(e => e.AssetHeaders)
        .WithRequired(e => e.AssetEquipment)
    	.HasForeignKey(e => e.AssetEquipmentId)
        .WillCascadeOnDelete(false);
    
    modelBuilder.Entity<AssetHeader>()
        .HasMany(e => e.AssetEquipment)
        .WithRequired(e => e.AssetHeader)
    	.HasForeignKey(e => e.AssetHeaderId)
        .WillCascadeOnDelete(true);
