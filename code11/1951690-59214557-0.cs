C#
private void dgvLocataire_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvLocataire.BeginEdit(false);
            
            var ec = dgvLocataire.EditingControl as DataGridViewComboBoxEditingControl;
            if (ec != null && ec.Width - e.X < SystemInformation.VerticalScrollBarWidth)
                ec.DroppedDown = true;
            if ((e.ColumnIndex != 3) && (e.ColumnIndex != 4))
            {
                dgvLocataire.Columns[e.ColumnIndex].ReadOnly = true;
            }
     
        }
private void dgvLocataire_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox cb = e.Control as ComboBox;
            if (cb != null)
            {
                cb.SelectionChangeCommitted -= new EventHandler(ComboBox_SelectedIndexChanged);
                // now attach the event handler
                cb.SelectionChangeCommitted += new EventHandler(ComboBox_SelectedIndexChanged);
            }
        }
private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            string item = cb.Text;
            if (item != null)
                MessageBox.Show(item);
        }
`
but now i dont get the messagebox to show ???
any help ?
Thanks
