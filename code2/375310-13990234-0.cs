                            if (oCell is DataGridViewComboBoxCell)
                            {
                                 DataGridViewComboBoxCell tmp = oCell as DataGridViewComboBoxCell;
                                 if (tmp.Items.Contains(sCells[i]))
                                 {
                                     tmp.Value = tmp.Items[tmp.Items.IndexOf(sCells[i])];
                                 }
                            }
