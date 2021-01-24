    int counter = 1;
    var rows = dataGridView1.Rows.OfType<DataGridViewRow>().Reverse().Skip(1); 
    //ignore the last empty line
    var dupRos = rows.GroupBy(r => r.Cells["Date"].Value.ToString()).Where(g => 
    g.Count() > 1).SelectMany(r => r.ToList());
    string lastDupRowDate = null;
    foreach (var r in dupRos)
    {
        r.DefaultCellStyle.BackColor = Color.Pink;
        r.Cells["Time"].Value = "Dup" + counter;
        counter = lastDupRowDate == r.Cells["Date"].Value.ToString() ? count + 1 : 1;
        lastDupRowDate = r.Cells["Date"].Value.ToString();
    }
    foreach (var r in rows.Except(dupRos))
    {
        r.DefaultCellStyle.BackColor = Color.Cyan;
        r.Cells["Time"].Value = "Unick";
    }
