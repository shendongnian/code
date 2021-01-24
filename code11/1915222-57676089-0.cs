    [HttpPost]
    public async Task<IHttpActionResult> GetAccountsAsync(IEnumerable<int> accountIds)
    {
        Task<List<AccountDetail>>[] tasks = accountIds.Select(accountId => GetAccountDetailAsync(accountId)).ToArray();
        List<AccountDetail>[] results = await Task.WhenAll(tasks);
        return Ok(results.SelectMany(x => x).ToList());
    }
