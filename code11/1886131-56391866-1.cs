    public void Configure(EntityTypeBuilder<CostCenter> costCenterEntity)
    {
        ...
        costCenterEntity.HasOptional(costCenter => costCenter.OwnerId)                    // The owner is optional
            .WithMany(owner => owner.CostCenters)  // the owner has zero or more CostCenters
            .HasForeignKey(costCenter => costCenter.OwnerId)
    }
