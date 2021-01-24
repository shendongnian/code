    foreach(DataGridViewRow row in dataGridView.Rows) {
        for(int i = 0; i < row.Cells.Count; i++) {
            int fieldID = Convert.ToInt32(row.Cells[0].Value);
            String fieldName = dictionary[fieldID];
            row.Cells[1].Value = fieldName;
        }
    }
    FieldColumn.Visible = false;
