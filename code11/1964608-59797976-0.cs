    public static string SetValueForText1 = "";
            private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
                // get the row index of the cell clicked
                var rowIndex = e.RowIndex;
    
                //specify 0, if the Id is in the first Column else in place of 0 e.ColumnIndex
                var id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                SetValueForText1 = id;
                var newForm = new container_departure_details();
              
                newForm.Show();
            }
