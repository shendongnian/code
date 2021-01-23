    private void MapUserRelations<TEntity>(DbModelBuilder modelBuilder) 
        where TEntity : Audit
    {
        modelBuilder.Entity<TEntity>().HasOptional(u => u.CreateUser).WithMany().HasForeignKey(u => u.CreateUserId).WillCascadeOnDelete(false);
        modelBuilder.Entity<TEntity>().HasOptional(u => u.UpdateUser).WithMany().HasForeignKey(u => u.UpdateUserId).WillCascadeOnDelete(false); 
    }
