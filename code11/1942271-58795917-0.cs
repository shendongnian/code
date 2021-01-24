    protected void dgvAdressBook_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
           foreach (DataGridViewRow row in dgv_ClientDetail.Rows)
            {
              DataGridViewComboBoxCell BankersCombo = (DataGridViewComboBoxCell)(row.Cells[index of BankersCombo column]);
              BankersCombo.DataSource = // your contacts datasource;
              BankersCombo.DisplayMember = "name of field to be displayed like say ContactName";
              BankersCombo.ValueMember = "Id";
            }
    }
