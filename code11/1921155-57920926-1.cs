     public async Task<List<User>> GetChilds(int userId)
        {
         List<User> newChilds = new List<User>();
            var childs = await _dbContext.Users.Where(x => x.ManagerId == userId).ToList();
            if (childs != null)
            {
                foreach (var child in childs)
                {
                    var childChildreen = await GetChilds(child.Id);
                    if(childChildreen != null)
                    {
                        newChilds.AddRange(childChildreen);
                    }
                  
                }
                childs.AddRange(newChilds);
            }
            return childs;
        }
