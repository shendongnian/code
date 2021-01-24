    [HttpGet("/ListAllItems")]
    public async Task<Wrapper<IEnumerable<DtoModel>>> ListAllItemsFromDb()
    {
        return new Wrapper<<IEnumerable<DtoModel>>() {
           Value = await _dbProvider.ListAllItemsAsync()
        };
    }
