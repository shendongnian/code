    protected override void OnModelCreateing(DbModelBuilder modelBuilder)
    {
       modelBuilder.Entity<ContractPart>()
                   .HasKey(cp => new { cp.ContractId, cp.PartId });
       modelBuilder.Entity<Contract>()
                   .HasMany(c => c.ContractParts)
                   .WithRequired()
                   .HasForeignKey(cp => cp.ContractId);
       modelBuilder.Entity<Part>()
                   .HasMany(p => p.ContractParts)
                   .WithRequired()
                   .HasForeignKey(cp => cp.PartId);  
    }
