    var userEntity = modelBuilder.Entity<User>();
    // every user has zero or more FromMessages (one-to-many)
    userEntity.HasMany(user => user.FromMessages)
              .WithRequired(message => message.From)
              .HasForeignKey(message => message.FromUserId);
    // every user has zero or more ToMessages (one-to-many)
    userEntity.HasMany(user => user.ToMessages)
              .WithRequired(message => message.To)
              .HasForeignKey(message => message.ToUserId);
