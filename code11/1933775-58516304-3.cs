    private void dataGridView1_SelectionChanged(object sender, EventArgs e) {
      if (ColumnShown) {
        if (ValueGreaterThan20) {
          int curColIndex = dataGridView1.CurrentCell.ColumnIndex;
          if (dataGridView1.Columns[curColIndex].Name == "HideColumn") {
            dataGridView1.CurrentCell = dataGridView1.Rows[PreviousRow].Cells["ConditionColumn"];
            dataGridView1.CurrentCell.Selected = true;
          }
          dataGridView1.Columns["HideColumn"].Visible = false;
          ColumnShown = false;
        }
      }
      else {
        if (!ValueGreaterThan20) {
          dataGridView1.Columns["HideColumn"].Visible = true;
          ColumnShown = true;
        }
      }
    }
