    private void GetUsers(IReadOnlyCollection<Users> totalUsers, bool useDatabase)
    {
        IQueryable<Users> userSource;
        if(useDatabase)
        {
            userSource = datalayerModel;
        }
        else
        {
            userSource = totalUsers.AsQueryable();
        }
        
        userSource.Where(x => x.CompanyId == 1 &&
                              x.EmployerId == 1 &&
                              x.EmployeeId == 1);
    }
