        private  IEnumerable<ProvinceWithBranches> Get(string filter)
              {
                 var firstConditionResults= source.Where(p => p.Province == filter);
                  var secondConditionResults = source.Where(p => p.Province  !=filter).Select(p=>new ProvinceWithBranches{
    Value = p.Value,
    Province = p.Province,
    Branches = p.Branches.Where(branch=>branch.Province==filter) } );
        
                  return firstConditionResults.Concat(secondConditionResults);
              }
