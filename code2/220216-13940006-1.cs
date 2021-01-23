    protected override void OnCellClick(DataGridViewCellEventArgs e)
    {
        // Normally the user would need to click a combo box cell once to 
        // activate it and then again to drop the list down--this is annoying for 
        // our purposes so let the user activate the drop-down with a single click.
        if (e.ColumnIndex == this.Columns["YourDropDownColumnName"].Index
            && e.RowIndex >= 0
            && e.RowIndex <= this.Rows.Count)
        {
            this.CurrentCell = this[e.ColumnIndex, e.RowIndex];
            this.BeginEdit(false);
            ComboBox comboBox = this.EditingControl as ComboBox;
            if (comboBox != null)
            {
                comboBox.DroppedDown = true;
            }
        }
    
        base.OnCellContentClick(e);
    }
