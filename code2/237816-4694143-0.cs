    var table = batchaddresses.Select((xx,ii) => new { Value = xx, Order = ii })
                    .Join(dataTable.AsEnumerable(),
                          (outer) => outer.Value,
                          (inner) => inner.Field<string>("ThirdColumn"),
                          (outer, inner) => new { Order = outer.Order, Row = inner })
                    .OrderBy(xx => xx.Order)
                    .Select(xx => xx.Row)
                    .CopyToDataTable();
