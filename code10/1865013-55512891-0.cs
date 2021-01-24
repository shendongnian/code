	private void button2_Click(object sender, EventArgs e)
	{
		DataGridViewTextBoxColumn Column3New = new DataGridViewTextBoxColumn();
		Column3New.Name = "Column3";
		Column3New.HeaderText = "Column3";
		dataGridView1.Columns.RemoveAt(3);
		dataGridView1.Columns.Insert(3, Column3New);
		for (int i = 0; i < dataGridView1.RowCount; i++)
		{
			if (!RowIsEmpty(i))
			{
				dataGridView1[3, i].Value = Combo.Text;
			}
		}
	}
