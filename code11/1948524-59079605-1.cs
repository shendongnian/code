    var q = baseTable.AsEnumerable()
                     .GroupBy(row => columnsToGroupBy.Select(c => row[c]), comparer) //eg: day, time, country
                     .Select(group => new {
                         AllKeys = group.Key,
                         AllField = group.Sum(row => double.Parse(row["rain"].ToString()))
                     })
                     .OrderBy(r => r.AllKeys, new IEnumerableComparer());
