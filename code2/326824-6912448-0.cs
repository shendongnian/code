    var task = _repo.Single<Task>
                (x => x.HouseID == _house.HouseID && x.CompanyID == loggedonuser.CompanyID);
        var dto = new TaskDTO
        {
            TaskID = task.TaskID,
            Title = task.Title,
            Description = task.Description,
            DateCreated = task.DateCreated,
            IsClosed = task.IsClosed,
            CompanyID = companies.Where(y => task.CompanyID == y.CompanyID).SingleOrDefault().Identifier
        };
