        private void Lot_dataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                if (ColIndex == "2") // this colIndex i got it from CellEnter event.
                {
                    DataGridViewTextBoxEditingControl te = (DataGridViewTextBoxEditingControl)e.Control;
                    te.TextChanged += new EventHandler(textbox_TextChanged);
                }
            }
        }
