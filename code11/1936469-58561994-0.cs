Main
{
   var query = model.Runs.Where(...);
   query = AddSortLogic(query);
   var finalQuery = query.GroupBy(...).Select(...);
}
private IQueryable<Runs> AddSortLogic(IQueryable<Runs> query)
{
   if(ShowMasterBranchOnly)
   {
      query = query.Where(...)
         .SortBy(...)
         .ThenBy(...);
   }
   else
   {
      query = query.SortBy(...);
   }
   return query;
}
