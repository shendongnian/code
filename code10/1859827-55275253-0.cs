    var dateTimes = dataGridView1.Rows.Cast<DataGridViewRow>()
                //.Select(x => (DateTime) x.Cells["ColumnName"].Value); //if column type datetime
                //or    
                .Select(x => Convert.ToDateTime(x.Cells["ColumnName"].Value));
    var minValue = dateTimes.Min();
    var maxValue = dateTimes.Max();
