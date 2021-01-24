    Func<MyDataType, DateTime> selectKey;
    switch (PublicVariables.customfiltersetting)
    {
        case 0:
            goto default;
        case 1:
            selectKey = s => new DateTime(s.Date.Year, s.Date.Month, s.Date.Day, s.Date.Hour, s.Date.Minute, 0);
            break;
        case 2:
            selectKey = s => new DateTime(s.Date.Year, s.Date.Month, s.Date.Day, s.Date.Hour, 0, 0);
            break;
        case 3:
            selectKey = s => new DateTime(s.Date.Year, s.Date.Month, s.Date.Day, 0, 0, 0);
            break;
        case 4:
            selectKey = s => new DateTime(s.Date.Year, s.Date.Month, 1, 0, 0, 0);
            break;
        case 5:
            selectKey = s => new DateTime(s.Date.Year, 1, 1, 0, 0, 0);
            break;
        default:
            selectKey = s => new DateTime(s.Date.Year, s.Date.Month, s.Date.Day, s.Date.Hour, s.Date.Minute, s.Date.Second);
            break;
    }
    var ordering = from s in Filter.FullData()
                   group s by selectKey(s) into g
                   let count = g.Count()
                   orderby g.Key descending
                   select new { Date = g.Key, Column = g.Average(s => s.Column), Count = count };
