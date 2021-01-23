    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String info;
			
            if (e.ColumnIndex == 0) // Here specify the column index on click of which you want to display popup
            {
				//your logic here
				info= dataGridView1.Rows[e.RowIndex].Cells["U_ID"].Value).toString();  // Cells["<specify your cell name for this index>"]
				MessageBox.Show(info);
			}
			
			else if (e.ColumnIndex == 1) // Here specify the column index on click of which you want to display popup
            {
				//your logic here
				info= dataGridView1.Rows[e.RowIndex].Cells["Name"].Value).toString();  // Cells["<specify your cell name for this index>"]
				MessageBox.Show(info);
			}
		}
