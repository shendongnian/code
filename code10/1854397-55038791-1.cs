    private void CRUD_SelectionChanged(object sender, EventArgs e)
    {
        if (CRUD.SelectedRows.Count() == 1) // check if a row and only one is selected
        {
            txtBoxID.Text = CRUD.SelectedRows[0].Cells[0].Value.ToString();
            txtBoxStates.Text = CRUD.SelectedRows[0].Cells[1].Value.ToString();
            txtBoxName.Text = CRUD.SelectedRows[0].Cells[2].Value.ToString();
            txtBoxAddress.Text = CRUD.SelectedRows[0].Cells[3].Value.ToString();
            txtBoxCenter.Text = CRUD.SelectedRows[0].Cells[4].Value.ToString();
            txtBoxCity.Text = CRUD.SelectedRows[0].Cells[5].Value.ToString();
        }
    }
