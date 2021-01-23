    DataTable output = new DataTable();
    using (var e = dataTable.AsEnumerable().GetEnumerator())
    {
        if (!e.MoveNext())
            // No data in the datatable at all
            return;
        // Get first row
        var dt = (DateTime) e.Current["AccessDateTime"];
        var row = ((Direction) e.Current["Direction"] == Direction.In)
            ? new { Date = dt.Date, InTime = (TimeSpan?) dt.TimeOfDay, OutTime = (TimeSpan?) null }
            : new { Date = dt.Date, InTime = (TimeSpan?) null, OutTime = (TimeSpan?) dt.TimeOfDay };
        DataRow newRow;
        // Look at all the other rows
        while (e.MoveNext())
        {
            dt = (DateTime) e.Current["AccessDateTime"];
            if ((Direction) e.Current["Direction"] == Direction.Out && row.OutTime == null)
            {
                row = new { Date = row.Date, InTime = row.InTime, OutTime = (TimeSpan?) dt.TimeOfDay };
                continue;
            }
            newRow = output.NewRow();
            newRow["Date"] = row.Date;
            newRow["InTime"] = row.InTime;
            newRow["OutTime"] = row.OutTime;
            row = new { Date = dt.Date, InTime = (TimeSpan?) dt.TimeOfDay, OutTime = (TimeSpan?) null };
        }
        newRow = output.NewRow();
        newRow["Date"] = row.Date;
        newRow["InTime"] = row.InTime;
        newRow["OutTime"] = row.OutTime;
    }
