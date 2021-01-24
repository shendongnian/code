    public async Task<Response> GetAllVasInformationAsync()
    {
        var userDetails = GetUserDetailsAsync();
        var getWageInfo = GetUserWageInfoAsync();
        var getSalaryInfo = GetSalaryInfoAsync();
        await Task.WhenAll(userDetails, getWaitInfo, getSalaryInfo)
           .ContinueWith((task) =>
           {
              if(task.IsFaulted)
              { return some sort of error}
        });
        var resultToReturn = new Response
        {
            IsuserDetailsSucceeded = userDetails.Result,
            IsgetWageInfoSucceeded = getWageInfo.Result,
            IsgetSalaryInfoSucceeded = getSalaryInfo.Result,
        };
        return resultToReturn;
    }
