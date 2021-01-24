            private void CboQuery_SelectedIndexChanged(object sender, EventArgs e)
            {
    
                try
                {
                    cboQuery.DropDownStyle = ComboBoxStyle.DropDownList;
                }
                catch (Exception ex)
                {
                    throw;
                }
                if (cboQuery.SelectedIndex > 0 && cboJob.SelectedIndex > 0) // ADDITIONAL CONDITION!
                {
                    if (_jobs[cboJob.SelectedIndex - 1].Queries.Count > 0)
                    {
                        txtSQL.Enabled = true;
                        btnDeleteQuery.Enabled = true;
                        txtSQL.Text = _jobs[cboJob.SelectedIndex - 1].Queries[cboQuery.SelectedIndex - 1].Sql;
                    }
                    else
                    {
                        btnDeleteQuery.Enabled = false;
                        txtSQL.Enabled = false;
                    }
                }
                else
                {
                    btnDeleteQuery.Enabled = false;
                    txtSQL.Enabled = false;
                }
                if (cboQuery.SelectedIndex == 0)
                {
                    try
                    {
                        cboQuery.DropDownStyle = ComboBoxStyle.DropDown;
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
