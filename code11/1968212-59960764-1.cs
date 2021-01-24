    public async Task<List<TestModel>> Report(TestModel model)
    {
        var linkType = await _LinkRepo.ListQueryable(log => (string.IsNullOrEmpty(model.Name) || log.Code.Contains(model.Name))).ToListAsync();
        var click = await _ClickRepo.ListQueryable(log => (string.IsNullOrEmpty(model.Code) || log.Code.Contains(model.Code))).ToListAsync();
        return  (from t in linkType
                      join d in click on t.Id equals d.linkRepoId into sr
                      from x in sr.DefaultIfEmpty()
                      where t != null
                      select new TestModel
                      {
                          Code = x.Code,
                          Name = x.Name,
                      }).ToList();
    }
