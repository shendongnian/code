    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex].Name == "queryButtonColumn" &&
                e.RowIndex >= 0)
            {
                var xml = ((WhoIsActive)dataGridView1.CurrentRow.DataBoundItem).XmlCol;
                Form2 display = new Form2(xml);
                //Show dialog or normally accordingly...
                //display.Show();
                display.ShowDialog();
                
            }
        }
