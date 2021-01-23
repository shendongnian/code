    var gridViewResults = (from results in db.Components
                           where results.DisableFlag == false
                           select new
                           {
                             SNo = 0,
                             ComponentNames = results.Component_Name,
                             Size = results.Size__in_MB_,
                             Price = results.Price__in_SEK_,
                             TotalDownloads = results.Total_Downloads,
                             Description = results.Description
                           }).ToList();
    int SNo = 1;
    foreach (var item in gridViewResults) {
      item.SNo = SNo;
      SNo++;
    }
    // use gridViewResults like you were before, it's now an
    // anonymous IList but implements IEnumerable like the query did.
