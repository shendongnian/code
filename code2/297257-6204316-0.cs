    var query = from r in data.AsEnumerable()
        orderby r.Field<string>(0), r.Field<DateTime>(2)
                        select new Test
                                   {
                                       Name = r.Field<string>(0),
                                       DateReported = r.Field<DateTime>(2)
                                   };
