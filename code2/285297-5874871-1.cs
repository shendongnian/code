    var gridViewResults = from results in db.Components
                          where results.DisableFlag == false
                          select new
                          {
                            SNo = 0,
                            ComponentNames = results.Component_Name,
                            Size = results.Size__in_MB_,
                            Price = results.Price__in_SEK_,
                            TotalDownloads = results.Total_Downloads,
                            Description = results.Description
                          };
    gridViewResults = gridViewResults.Select((item, index) => 
                      {
                         item.SNo = index + 1;
                         return item;
                      })
