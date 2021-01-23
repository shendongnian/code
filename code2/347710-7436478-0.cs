    tbl = new DataTable();
    foreach(var day in Week) {
        tbl.Columns.Add(new DataColumn(day.Name, Task));
    }
    foreach(var cat in Categories) {
        var tasks = AllTasks.Where(t => t.Category.equals(cat) && Week.Contains(t.Day));
        if (tasks.Any()) {
            foreach (var task in tasks) { 
                var row = new DataRow();
                row.SetField(day.Name, task);
                tbl.Rows.Add(row);
            }
        }
    }
