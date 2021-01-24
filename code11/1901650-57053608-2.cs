    [HttpGet("/ListAllItems")]
    public async Task<Wrapper<IEnumerable<DtoModel>>> ListAllItemsFromDb()
    {
        return new Wrapper<<IEnumerable<DtoModel>>() {
           Data = await _dbProvider.ListAllItemsAsync()
        };
    }
