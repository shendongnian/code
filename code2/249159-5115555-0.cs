            DataGridViewRow row = GridStockItemEntry.CurrentRow;
            DataGridViewCell cell = GridStockItemEntry.CurrentCell;
            if (e.Control.GetType() == typeof(DataGridViewComboBoxEditingControl))
            {
                if (cell == row.Cells["ItemName"] && Convert.ToString(row.Cells["Type"].Value) == "Raw Material")
                {
                    DataGridViewComboBoxEditingControl cbo = e.Control as DataGridViewComboBoxEditingControl;
                    cbo.DropDownStyle = ComboBoxStyle.DropDown;
                    cbo.Validating += new CancelEventHandler(cbo_Validating);
                }
            }
            
           
        }
        void cbo_Validating(object sender, CancelEventArgs e)
        {
            DataGridViewComboBoxEditingControl cbo = sender as DataGridViewComboBoxEditingControl;
            DataGridView grid = cbo.EditingControlDataGridView;
            object value = cbo.Text;
            // Add value to list if not there
            if (cbo.Items.IndexOf(value) == -1)
            {
                DataGridViewComboBoxCell cboCol = (DataGridViewComboBoxCell)grid.CurrentCell;
                // Must add to both the current combobox as well as the template, to avoid duplicate entries...
                cbo.Items.Add(value);
                cboCol.Items.Add(value);
                grid.CurrentCell.Value = value;
            }
        }
