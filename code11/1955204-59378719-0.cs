public async Task<List<TimeEntryViewModel>> GetApproved(TimeEntryFilter filter)
        {
            var result = await _readRepository
                .FindByCondition(x => x.IsApproved == true)
                .Include(x => x.Task)
                .Include(x => x.Account)
                .Where(x => 
                            (string.IsNullOrEmpty(filter.InternalId.ToString()) || x.InternalId.ToString().Contains(filter.InternalId.ToString())) &&
                            (string.IsNullOrEmpty(filter.AccountName) || x.Account.Name.Contains(filter.AccountName)) && 
                            (string.IsNullOrEmpty(filter.CustomerName) || x.Task.Project.ServiceOrder.Customer.Name.Contains(filter.CustomerName)) &&
                            (string.IsNullOrEmpty(filter.TaskName) || x.Task.Name.Contains(filter.TaskName)))
                .Select(x => new TimeEntryViewModel
                {
                    Id = x.Id,
                    AccountName = x.Account.Name,
                    Date = x.Date,
                    Description = x.Description,
                    StartTime = x.StartTime,
                    FinishTime = x.FinishTime,
                    InternalId = x.InternalId,
                    OnSite = x.OnSite,
                    IsApproved = x.IsApproved,
                    IsBillable = x.IsBillable,
                    TaskId = x.TaskId,
                    TaskName = x.Task.Name,
                    CreatedBy = x.CreatedBy,
                    CustomerName = x.Task.Project.ServiceOrder.Customer.Name
                }).ToListAsync().ConfigureAwait(false);
            return result;
        }
If anyone knows why it's working, I'll be thankful 
