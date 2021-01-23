     private void dgvTodaysPlan_CurrentCellDirtyStateChanged(object sender, EventArgs e)
            {
                if (dgvTodaysPlan.CurrentCell is System.Windows.Forms.DataGridViewCheckBoxCell)
                {
                    dgvTodaysPlan.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
    
            }
