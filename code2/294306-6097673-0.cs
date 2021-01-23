     private void dataGridView_CellValidated(object sender, DataGridViewCellEventArgs e) {
                    if (e.RowIndex > -1) {
                        DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                        string valueA = row.Cells[columnA.Index].Value.ToString();
                        string valueB = row.Cells[columnB.Index].Value.ToString();
                        int result;
                        if (Int32.TryParse(valueA, out result)
                            && Int32.TryParse(valueB, out result)) {
                            row.Cells[columnTotal.Index].Value = valueA + valueB;
                        }
                    }
                }
