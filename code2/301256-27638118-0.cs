        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                switch (dataGrid_ItemsList.Columns[dataGrid_ItemsList.SelectedCells[0].ColumnIndex].HeaderText)
                {
                    case "Batch":
                        if (e.Control is ComboBox)
                        {
                            ComboBox _with1 = (ComboBox)e.Control;
                            _with1.DropDownStyle = ComboBoxStyle.DropDown;
                            _with1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            _with1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                            _with1.AutoCompleteCustomSource = BatchList;
                            //_with1.Validating -= HandleComboBoxValidating;
                            //_with1.Validating += HandleComboBoxValidating;
                            _with1.Validating += (ss, ee) =>
                            {
                                if (!_with1.Items.Contains(_with1.Text))
                                {
                                    var comboColumn = dataGrid_ItemsList.CurrentCell as DataGridViewComboBoxCell;
                                    _with1.Items.Add(_with1.Text);
                                    _with1.Text = _with1.Text;
                                    comboColumn.Items.Add(_with1.Text);
                                    this.dataGrid_ItemsList.CurrentCell.Value = _with1.Text;
                                }
                            };
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                _CommonClasses._Cls_ExceptionsHandler.HandleException(ex,false);
            }
        }
