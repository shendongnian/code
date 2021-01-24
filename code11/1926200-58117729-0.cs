     if(dgvSoup==null || dgvSoup.CurrentCell==null)
     {
            MessageBox.Show("No Cell selected");
     } 
     else{ 
            object soup = dgvSoup.CurrentCell.Value;
            string msg = string.Format("Row: {0}, column: {1}",
            dgvSoup.CurrentCell.RowIndex,
            dgvSoup.CurrentCell.ColumnIndex);
        if (dgvSoup.CurrentCell.ColumnIndex > 0)
        {
            MessageBox.Show("You Must Select from" +
                "the RecID Column", "Selection Error");
        }
        if (dgvSoup.CurrentCell.ColumnIndex == 0)
        {
            int RecID = Convert.ToInt32(soup);
            this.SoupClearControls();
            this.GetSoupRecipe(RecID);
            this.DisplaySoupRecipe();
        }
     }
