     try
                {
                   var usersToUpdate = await dbContext.MyList.Where(x=>x.Id==myId).ToListAsync();
    
                   usersToUpdate.ForEach(x=>{..make updates..});
    
                    await dbContext.SaveChangesAsync();
                }
                catch (Exception e)
            {
               ..Error handling..
            }
