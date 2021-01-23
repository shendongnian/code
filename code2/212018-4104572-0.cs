    List<Cards> target = dt.AsEnumerable()
                           .Select(row => new Cards
                                   {
                                       // assuming column 0's type is Nullable<long>
                                       CardID = row.Field<long?>(0).GetValueOrDefault()
                                   })
                           .ToList();
