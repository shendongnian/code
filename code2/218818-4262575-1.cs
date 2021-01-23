        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (e.ColumnIndex == 0) {  // Assumes column 0 has the data that determines if a button should be displayed.
                if (e.Value.ToString() == "bob") {  // Test if a button should be displayed on row.
                    // Create a Button and add it to our DGV.
                    Button cellButton = new Button();
                    // Do something to identify which row's button was clicked.  Here I'm just storing the row index.
                    cellButton.Tag = e.RowIndex;
                    cellButton.Text = "Hello bob";
                    cellButton.Click += new EventHandler(cellButton_Click);
                    dataGridView1.Controls.Add(cellButton);
                    // Your ugly button column is shown here as having an index value of 3.
                    Rectangle cell = this.dataGridView1.GetCellDisplayRectangle(3, e.RowIndex, true);
                    cellButton.Location = cell.Location;
                }
            }
        }
            
