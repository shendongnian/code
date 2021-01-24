    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        var messageEntity = modelBuilder.Entity<Message>();
        // every messages belongs to exactly one User using foreign key `FromUserId`
        // every such User has zero or more From messages
        messageEntity.HasRequired(message => message.From)
                     .WithMany(user => user.FromMessages)
                     .HasForeignKey(message => message.FromUserId)
        // the same for To, using ToUserId:
        messageEntity.HasRequired(message => message.To)
                     .WithMany(user => user.ToMessages)
                     .HasForeignKey(message => message.ToUserId);
    }
