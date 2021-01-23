    var query = from row in dTable.AsEnumerable()
                        group row by row.Field<double>("ITEM_NO") into grp
                        orderby grp.Key
                        select new
                        {
                            ITEM_NO = grp.Key,
                            sum = grp.Sum(r => r.Field<double>("ITEM_STOCK"))
                        };
