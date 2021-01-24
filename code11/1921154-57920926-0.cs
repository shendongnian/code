     public async Task<List<User>> GetChilds(int userId)
        {
            List<User> childs = new List<User>();
            childs = await _dbContext.Users.Where(x=>x.ManagerId == userId).ToListAsync();
            if(childs !=null )
            {
                foreach (var child in childs)
                {
                    var newChilds = await GetChilds(child.Id);
                    childs.AddRange(newChilds);
                }
            }
       
            return childs;
        }
