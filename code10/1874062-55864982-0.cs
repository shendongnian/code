    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
          base.OnModelCreating(modelBuilder);
          modelBuilder.Entity<ExecutionResult>().HasRequired(er => er.SendedAnswer)
                .WithMany(sa => sa.ExecutionResults).HasForeignKey(er => er.SendedAnswerId)
                .WillCascadeOnDelete(false);
          modelBuilder.Entity<ExecutionResult>().HasRequired(er => er.Answer)
                .WithMany().HasForeignKey(er => er.AnswerId).WillCascadeOnDelete(false);
    }
