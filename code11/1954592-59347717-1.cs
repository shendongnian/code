     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
                modelBuilder.Entity<User>().HasOne(t => t.Participant)
                         .WithOne(t => t.User)
                          .HasForeignKey<Participant>(t => t.UserId);
    
                modelBuilder.Entity<Participant>().HasOne(t => t.User)
                         .WithOne(t => t.Participant)
                         .HasForeignKey<User>(t => t.ParticipantId);
                base.OnModelCreating(modelBuilder);
     }
