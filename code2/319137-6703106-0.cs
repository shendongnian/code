    select new {
       attempt.ID,attempt.DateStarted,
       attempt.NumberFailed,attempt.NumberProcessed,
    }).AsEnumerable().Select(x => new ImportUserAttemptViewModel {
       ID = x.ID,
       When = x.DateStarted,
       NumberFailed = x.NumberFailed,
       NumberProcessed = x.NumberProcessed,
       UserName = userInfoServices.GetUserName(x.UserID)
    });
