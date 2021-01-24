    else if (txtTitulo.Text == "" && txtIngredientes.Text != "")
    {
        string searchValue = txtIngredientes.Text;
        dataGridReceitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        try
        {
            bool valueResult = false;
            foreach (DataGridViewRow row in dataGridReceitas.Rows)
            {
				if (row.Cells[3].Value != null && row.Cells[3].Value.ToString().Equals(searchValue))
				{
					int rowIndex = row.Index;
					dataGridView1.Rows[rowIndex].Selected = true;
					valueResult = true;
					break;
				}
            }
            if (!valueResult)
            {
                MessageBox.Show("Unable to find " + searchtextBox.Text, "Not Found");
                return;
            }
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message);
        }
    }
