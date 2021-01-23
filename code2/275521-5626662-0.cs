            using (Entities ctx = new Entities())
            {
                ctx.Statuses.Attach(status);
                ObjectStateEntry entry = ctx.ObjectStateManager.GetObjectStateEntry(status);
                entry.ChangeState(EntityState.Modified);
                //get the first user from the database
                User user = ctx.Users.Where(u => u.Id = 1);
                //set user status to some existing status
                user.StatusID = status.StatusID;
                ctx.SaveChanges();
            }
