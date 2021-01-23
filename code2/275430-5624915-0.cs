	private void CheckCellValue(object sender, DataGridViewCellEventArgs e)
	{
            //my column index on the date is 0; modify yours as needed!
	    if (e.ColumnIndex == 0 && e.RowIndex > -1 && e.RowIndex != dataGridView1.NewRowIndex)
		{
			//check whether this can be parsed as a date.
			string enteredVal = dataGridView1.CurrentCell.Value.ToString();
			DateTime dt;
			if (DateTime.TryParse(enteredVal, out dt))
			{
				dataGridView1.CurrentCell.Value = dt.ToString("dd-MMM-yyyy");
			}
			else
			{
				MessageBox.Show("Doh, that's not a date: " + enteredVal);
			}
		}
	}
