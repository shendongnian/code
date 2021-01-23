        OnSelectedIndexChanged="Grid_SelectedIndexChanged"
       void Grid_SelectedIndexChanged(Object sender, EventArgs e)
       {
         // Get the currently selected row using the SelectedRow property.
          GridViewRow row = Grid.SelectedRow;
         //Fill textboxes here
         Code.Text =  row.Cells[0].Text;
        }
