    void test(string columnName, bool visibility) {
      if (dataGridView1.Columns.Contains(columnName)) {
        dataGridView1.Columns[columnName].Visible = visibility;
      } else {
        throw new Exception(string.Format("Column '{0}' does not exist in DataGridView '{1}'.", columnName, dataGridView1.Name));
      }
    }
