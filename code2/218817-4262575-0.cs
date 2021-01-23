        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (e.ColumnIndex == 0) {
                if (e.Value == "bob") {  // Using your code here...
                    // Create a Button and add it to our DGV.
                    Button cellButton = new Button();
                    // Store data to identify this particular button.  I'm using the RowIndex.
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
            
