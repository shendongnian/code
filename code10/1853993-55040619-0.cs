    public async Task<PagedResult<UserList>> GetAll(string filter, int pageIndex, int pageSize, string sortColumn, string sortDirection)
            {
                filter = filter?.Trim().ToLower();
                var data = usersRepository.Query(true)
                    .Include(x => x.UserRoles)
                    .ThenInclude(x => x.Role)
                    .Select(x => new UserList()
                    {
                        Username = x.Username,
                        UserId = x.UserId,
                        IsActive = x.IsActive,
                        RoleId = x.UserRoles.FirstOrDefault().RoleId,
                        RoleName = x.UserRoles.FirstOrDefault().Role.Name
                    })
                    .AsQueryable();
    
                try
                {
                    if (!string.IsNullOrWhiteSpace(filter))
                    {
                        data = data.Where(x => x.Username.ToLower().Contains(filter) || x.RoleName.ToLower().Contains(filter));
                    }
    
                    //sort 
                    var ascending = sortDirection == "asc";
                    if (!string.IsNullOrWhiteSpace(sortColumn))
                    {
                        switch (sortColumn.Trim().ToLower())
                        {
                            case "username":
                                data = data.OrderBy(p => p.Username, ascending);
                                break;
                            case "isactive":
                                data = data.OrderBy(p => p.IsActive, ascending);
                                break;
                            case "rolename":
                                data = data.OrderBy(p => p.RoleName, ascending);
                                break;
                            default:
                                data = data.OrderBy(p => p.Username, ascending);
                                break;
                        }
                    }
                }
                catch (Exception e)
                {
                    //todo:
                }
    
                return await data.GetPaged(pageIndex, pageSize);
        }
