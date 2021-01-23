    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (tabControl1.SelectedIndex == 0)
        {
            bindingSource1.EndEdit();
            DataRow dataRow =  ((DataRowView)bindingSource1.Current).Row;
            if(dataRow.RowState != DataRowState.Modified)
            {
                return;
            }
            DialogResult userOption = MessageBox.Show("Save?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (userOption == System.Windows.Forms.DialogResult.Yes)
            {
                Save();
            }
        }
    }
