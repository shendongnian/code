    private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e) {
        if (e.StateChanged == DataGridViewElementStates.Selected) {
            Console.WriteLine("TRUE");
            dataGridView1.ReadOnly = true;
        }
    }
    
    private void dataGridView1_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e) {
        if (e.StateChanged == DataGridViewElementStates.Selected) {
            Console.WriteLine("false");
            dataGridView1.ReadOnly = false;
        }
    }
