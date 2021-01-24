    public async Task<List<AppUser>> GetAvailableUsers()
    {
            var userlist =new List<AppUser>();
            var userIds =await _dbContext.AppUser.Select(u => u.UserId).ToListAsync();
            foreach (var userid in userIds)
            {
                var flag = _secondService.HasRole(userid, 3);
                if (flag)
                {
                    var user = await _dbContext.AppUser.Where(x => x.IsActive).Where(x => x.UserId == userid).FirstOrDefaultAsync();
                    userlist.Add(user);
                }  
            }           
            return userlist;
    }
