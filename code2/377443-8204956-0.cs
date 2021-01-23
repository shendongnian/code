    data = dt.AsEnumerable()
        .Select(r => columns.Select(c => new { Column = c.ColumnName, Value = r[c] })
        .ToDictionary(i => i.Column, i => i.Value != System.DBNull.Value ? i.Value : null))
        .Select(x => (object)x)
        .ToList();
