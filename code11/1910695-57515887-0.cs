         private void Clients_Load(object sender, EventArgs e)
                {
                  CreateDataGridView clientsdgv = new CreateDataGridView();
                  dgvClients = clientsdgv.dgvClients;
                 }
 
    private void TxtID_TextChanged(object sender, EventArgs e)
            {
    
                switch (this.cmbSelectAction.SelectedIndex)
                {
                    case 1:
    
                        Controls.Add(dgvClients);
                        dgvClients.BringToFront();
    
    
                        DesignDataGridView designdgv = new DesignDataGridView();
                        designdgv.ClientsDataGridPosition(dgvClients, this.txtID);
    
    
                        GetSqlData getSqlData = new GetSqlData();
    
                        if (string.IsNullOrEmpty(txtID.Text) || txtID.Text == "0")
                        {
    
                            dgvClients.DataSource = null;
                            dgvClients.Update();
                            dgvClients.Visible = false;
                            return;
                        }
                        else
                        {
                            try
                            {
                                dgvClients.SuspendLayout();
                                columnName = "PersonalIDBulstat";
                                ID = txtID.Text;
                                dgvClients.Visible = true;
                                dgvClients.DataSource = getSqlData.SearchClientsInSql(columnName, ID);
                                dgvClients.Update();
                                dgvClients.ResumeLayout();
                            }
                            catch
                            {
                                title = "Clients";
                                SetMessageBoxTypes.MessageBoxContactAdminOk(title);
                            }
                        }
                        break;
                }
            }
