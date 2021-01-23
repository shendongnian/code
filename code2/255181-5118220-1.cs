    return Json(
        (
            new
            {
                total = totalPages /*calculate this total records / rowsPerPage */,
                page = page /* passed in by jqgrid */,
                records = YourCollection.Count(),
                rows =
                    YourCollection.Select(x => new
                    {
                        i = x.RowIdentifier,
                        cell = new[]
                                {
                                    x.YourProperty,
    				x.YourOtherProperty,
    				x.YourOtherOtherProperty,
    				x.YouGetThePointProperty
                                }
                    }
                    ).ToArray()
            }
        )
        , JsonRequestBehavior.AllowGet);
