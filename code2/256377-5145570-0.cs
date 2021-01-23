        // Save event
        private void clientBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.clientBindingSource.EndEdit();
            Before_Update();
            this.tableAdapterManager.UpdateAll(this.dP_TestDataSet);
        }
        // Place logic in here to modify records if they are changed
        private void Before_Update()
        {
            if (dP_TestDataSet.HasChanges())
            {
                for (int tRow = 0; tRow < dP_TestDataSet.Tables["Client"].Rows.Count; tRow++)
                {
                    // Modification Logic
                    if (dP_TestDataSet.Tables["Client"].Rows[tRow].RowState == DataRowState.Modified)
                    {
                        dP_TestDataSet.Tables["Client"].Rows[tRow]["userID"] = Program.SYSNG.UserID;
                    }
                    // Addition Logic
                    if (dP_TestDataSet.Tables["Client"].Rows[tRow].RowState == DataRowState.Added)
                    {
                        // Addition Logic
                        // ...
                    }
                    // Other RowStates such as Deleted, Detatched or Unchanged work here too
                }
            }
        }
