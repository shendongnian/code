    public List<string> PerformSearch(Func<Action, string> selectCriteria)
    {
      
      return db.Actions.Include("Menus").Include("ActionDetails")
          .Where(x => x.ActionDetails.Any(y => y.Language.Culture == _currentCulture))
          .OrderBy(y => y.ActionDetails.Select(**selectCriteria**).Max())
          .Skip((pager.Index - 1) * pager.Take).Take(pager.Take)
          .ToList();
    }
