    public async Task<Response> GetAllVasInformationAsync()
    {
        var userDetails = GetUserDetailsAsync();
        var getWageInfo = GetUserWageInfoAsync();
        var getSalaryInfo = GetSalaryInfoAsync();
        await Task.WhenAll(userDetails, getWaitInfo, getSalaryInfo)
           .ContinueWith((task) =>
           {
              if(task.IsFaulted)
              { 
                 int failedCount = 0;
                 if(userDetails.IsFaulted) failedCount++;
                 if(getWaitInfo.IsFaulted) failedCount++;
                 if(getSalaryInfo.IsFaulted) failedCount++;
                 return $"{failedCount} tasks failed";
              }
        });
        var resultToReturn = new Response
        {
            IsuserDetailsSucceeded = userDetails.Result,
            IsgetWageInfoSucceeded = getWageInfo.Result,
            IsgetSalaryInfoSucceeded = getSalaryInfo.Result,
        };
        return resultToReturn;
    }
