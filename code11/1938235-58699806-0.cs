    public Task<SomeObject> GetSomeObjectByTokenAsync(int id)
    {
        string token = repository.GetTokenById(id);
        if (string.IsNullOrEmpty(token))
        {
            return Task.FromResult(new SomeObject()
            {
                IsAuthorized = false
            });
        }
        else
        {
            return InternalGetSomeObjectByTokenAsync(repository, token);
        }
    }
    
    internal async Task<SomeObject> InternalGetSomeObjectByToken(Repository repository, string token)
    {
        SomeObject result = await repository.GetSomeObjectByTokenAsync(token);
        result.IsAuthorized = true;
        return result;
    }
