            foreach (DataGridViewRow gridRow in dataGridView1.Rows)
            {
                if (_selectedIDs != null)
                    // *****
                    gridRow.Selected = false;
                    // *****
                    foreach (long id in _selectedIDs)
                    {
                        if ((long)((DataRowView)gridRow.DataBoundItem)["ObjectD"] == id)
                            gridRow.Selected = true;
                    }
                if (_checkedIDs != null)
                    foreach (long id in _checkedIDs)
                    {
                        ((DataRowView)gridRow.DataBoundItem)["Choosen"] = 0;
                        if ((long)((DataRowView)gridRow.DataBoundItem)["ObjectD"] == id)
                            ((DataRowView)gridRow.DataBoundItem)["Choosen"]=true;
                    }
            }
