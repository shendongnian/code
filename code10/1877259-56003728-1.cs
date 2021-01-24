    double d;
	foreach(DataGridViewRow r in DataGridView1.Rows)
	{
		if (r.IsNewRow) return;  //we don't want to do anything to the edit row.
	
    if (r.Cells[1].Value == null || r.Cells[10].Value.ToString() == "0")
	{
		r.Cells[1].Style.BackColor = Color.Red;
	}
	else if(double.TryParse(r.Cells[10].Value.ToString(), out d)) //if it can be parsed to a number
	{
		r.Cells[1].Style.BackColor = Color.Green;
	}
    else
    {
        //Cannot be parsed to a number 
        r.Cells[10].Style.BackColor = Color.Yellow;
    }
