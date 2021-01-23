        private void dataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox)
            {
                ComboBox cellComboBox = (ComboBox)e.Control;
                if (cellComboBox != null)
                {
                    cellComboBox.SelectedIndexChanged += new EventHandler(cellComboBox_SelectedIndexChanged);
                }
            }
        }
        void cellComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridViewComboBoxEditingControl comboBox = sender as DataGridViewComboBoxEditingControl;
            if (comboBox != null)
            {
                if (String.Compare(comboBox.Text, "Browse From File...") == 0)
                {
                    openFileDialog.ShowDialog();
                }
            }
        }
