c#
protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            if (entityEntry != null && entityEntry.State == EntityState.Added)
            {
                var errors = new List<DbValidationError>();
                ////User Validation
                if (entityEntry.Entity is ApplicationUser user)
                {
                    if (this.Users.Any(u => string.Equals(u.PhoneNumber, user.PhoneNumber)))
                    {
                        errors.Add(new DbValidationError("User",
                          string.Format($"Phonenumber {user.PhoneNumber} is already taken")));
                    }
                }
                if (errors.Any())
                {
                    return new DbEntityValidationResult(entityEntry, errors);
                }
            }
            return new DbEntityValidationResult(entityEntry, new List<DbValidationError>());
        }
