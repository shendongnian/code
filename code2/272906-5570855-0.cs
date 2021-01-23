        private OleDbConnection myConn;
        private OleDbDataAdapter dAdapter;
        private DataViewManager dviewmanager;
        private DataSet dset;
        private OleDbConnection myConn2;
        private OleDbDataAdapter dAdapter2;
        private DataViewManager dviewmanager2;
        private DataSet dset2;
        private void cmbDatabaseFill()
        {
            string conStr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=DB1.mdb";
            try
            {
                myConn = new OleDbConnection(conStr);
                myConn.Open();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Error in connection ..." + ex.Message);
            }
            string sqlStr = "SELECT * FROM Index;";
            dAdapter = new OleDbDataAdapter(sqlStr, myConn);
            dset = new DataSet();
            dAdapter.TableMappings.Add("Table", "Index");
            dAdapter.Fill(dset);
            this.dviewmanager = dset.DefaultViewManager;
            this.cmbMain.DataSource = this.dviewmanager;
            this.cmbMain.DisplayMember = "Index.List";
            this.myConn.Close();
        }
        private void cmbMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            clbDatabaseFill();
        }
        private void clbDatabaseFill()
        {
            string newTableName = cmbMain.Text.Replace(" ", "");
            string conStr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=DB1.mdb";
            try
            {
                myConn2 = new OleDbConnection(conStr);
                myConn2.Open();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Error in connection ..." + ex.Message);
            }
            string sqlStr = "SELECT * FROM " + newTableName + ";";
            dAdapter2 = new OleDbDataAdapter(sqlStr, myConn2);
            dset2 = new DataSet();
            dAdapter2.TableMappings.Add("Table", newTableName);
            try
            {
                dAdapter2.Fill(dset2);
            }
            catch (System.Exception)
            {
                return;
            }
            
            this.dviewmanager2 = dset2.DefaultViewManager;
            this.clbOpt.DataSource = this.dviewmanager2;
            this.clbOpt.DisplayMember = newTableName + ".ValName";
            this.myConn2.Close();
        }
