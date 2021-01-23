    var gridViewData = from results in db.Components
                               where results.DisableFlag == false
                               select new
                               {
                                   ComponentNames = results.Component_Name,
                                   Size = results.Size__in_MB_,
                                   Price = results.Price__in_SEK_,
                                   TotalDownloads = results.Total_Downloads,
                                   Description = results.Description
                               };
            var gridViewResults = gridViewData.AsEnumerable().Select((item, index) => new
            {
                SNo = index + 1,
                ComponentNames = item.ComponentNames,
                Size = item.Size,
                Price = item.Price,
                TotalDownloads = item.TotalDownloads,
                Description = item.Description
            }).ToList();
