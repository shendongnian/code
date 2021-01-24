    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuestionGroup>()
           .HasKey(t => new { t.QuestionId, t.GroupId });
            modelBuilder.Entity<QuestionGroup>()
                .HasOne(qg => qg.Question)
                .WithMany(q => q.QuestionGroups)
                .HasForeignKey(qg => qg.QuestionId);
            modelBuilder.Entity<QuestionGroup>()
                .HasOne(qg=>qg.Group)
                .WithMany(g => g.QuestionGroups)
                .HasForeignKey(qg => qg.GroupId);
       }
