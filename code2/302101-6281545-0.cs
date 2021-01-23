        private void lstItems_DoubleClick(object sender, EventArgs e)
        {
            if (lstItems.SelectedItem != null)
            {
                editForm editFrm = new editForm(lstItems.SelectedItem.ToString());
                editFrm.ShowDialog();
                lstItems.Items.Insert(lstItems.SelectedIndex, editFrm.Result);
                lstItems.Items.RemoveAt(lstItems.SelectedIndex);
            }
        }
