    public async Task<List<TestModel>> Report(TestModel model)
    {
       //code here
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
       
