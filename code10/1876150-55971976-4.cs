    var queryUsers = dbContext.User.Where(...).Where(...) ...
        .Select(user => new
        {
            // select only the user properties you really plan to use
            Id = user.Id,
            BirthDay = user.BirthDay,
            // Select the data in the format that you want, for example:
            FullName = user.FirstName + user.MiddleName + user.LastName,
            // SubCollections:
            Languages = user.Hobbies
               .Where(hobby => ...) // only if you don't want all this user's hobbies
               .Select(hobby => new
               {
                    // again, select only the hobby properties that you plan to use
                    Id = hobby.Id,
                    ...
                    // not needed, you already know the value:
                    // I know, it is probably a many-to-many, but let's suppose it is one-to-many
                    // UserId = hobby.UserId,
               })
               .ToList(),
               ...
        });
