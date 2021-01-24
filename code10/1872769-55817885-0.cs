	// Setup the DataGridView as in your example
	var dgv = new DataGridView();
	dgv.Columns.Add("s1", "s1");
	dgv.Columns.Add("s2", "s2");
	dgv.Columns.Add("s3", "s3");
	dgv.Columns.Add("s4", "s4");
	dgv.Columns.Add("s5", "s5");
	dgv.Columns.Add("s6", "s6");
	dgv.Columns.Add("DD", "DD");	
	dgv.Rows.Add("Fiona", "Lila", "Ben", "Ella", "Leon", "John", "Teachers");
	dgv.Rows.Add("Jack", "Luke", "Fiona", "Sophie", "Lila", "Leon", "Students");
	dgv.AllowUserToAddRows = false;
	dgv.Rows[0].Cells[0].Style.BackColor = Color.YellowGreen;
	dgv.Rows[0].Cells[1].Style.BackColor = Color.YellowGreen;
	dgv.Rows[0].Cells[4].Style.BackColor = Color.YellowGreen;
	dgv.Rows[1].Cells[2].Style.BackColor = Color.YellowGreen;
	dgv.Rows[1].Cells[4].Style.BackColor = Color.YellowGreen;
	dgv.Rows[1].Cells[5].Style.BackColor = Color.YellowGreen;
	// Query the DataGridView, counting each row's cells with the YellowGreen background color, correlating with the row name stored in the DD column
	var sums = dgv.Rows.Cast<DataGridViewRow>()
		.Select(row => new { 
			Name = row.Cells[row.Cells.Cast<DataGridViewCell>().First(cell => cell.OwningColumn.HeaderText == "DD").ColumnIndex].Value , 
			Count = row.Cells.Cast<DataGridViewCell>().Count(c => c.Style.BackColor == Color.YellowGreen)})
		.ToList();
	// Add the counts for each row to the ListView
	var lb = new ListBox();
	sums.ForEach(s => lb.Items.Add($"{s.Name}: {s.Count}"));
