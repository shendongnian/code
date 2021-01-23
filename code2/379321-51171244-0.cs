    for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
	{
		DataGridViewRow dataGridViewRow = dataGridView1.Rows[i];
		foreach (DataGridViewCell cell in dataGridViewRow.Cells)
		{
			string val = cell.Value as string;
		    if (string.IsNullOrEmpty(val))
			{
				if (string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[3].Value as string)) // If you want to check more then just one cell you could also add "&& (string.IsNullOrEmpty(dataGridView1.Rows[i].Cells[ANY NUMBER].Value as string)
				{
					MessageBox.Show(" cell is empty");
                    return;
                    /* or to delete replace with:
                    dataGridView1.Rows.Remove(dataGridViewRow);
					break;
                    */
				}
			}
		}
	}
