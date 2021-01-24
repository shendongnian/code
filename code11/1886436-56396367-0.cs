    using (var context = new UserEntity.UsersContext())
            {
                foreach(var u in users)
                {
                    var tempUser = await context.User.FirstOrDefaultAsync(x => x.Username == u.Username);
                    if (tempUser == null)
                    {
                        await context.AddAsync(u);
                    }
    
                    await context.SaveChangesAsync();
                }                
            }
