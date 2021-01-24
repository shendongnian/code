        private void CustomComboBoxColumns(string filter)
            {
                DataGridViewComboBoxColumn ComboBoxColumn = new DataGridViewComboBoxColumn();
                DataTable dt;
                ComboBoxColumn.HeaderText = "category";
                ComboBoxColumn.DataPropertyName = "category";
                ComboBoxColumn.ReadOnly = false;
                ComboBoxColumn.MaxDropDownItems = 100;
                ComboBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                ComboBoxColumn.FlatStyle = FlatStyle.Flat;
                ComboBoxColumn.ValueMember = "category";
                ComboBoxColumn.DisplayMember = "category";
                _iprDataGridView.Columns.Insert(16, ComboBoxColumn);
                for (int i = 0; i < _iprDataGridView.Rows.Count; i++)
                {
                    dt = GetDataForCategory(filter);
                 ((DataGridViewComboBoxCell)_iprDataGridView.Rows[i].Cells[16]).DataSource = dt;
                 ((DataGridViewComboBoxCell)_iprDataGridView.Rows[i].Cells[16]).DataBind(); //this edit
                }
            }
