    private void FillTable(string location, string supplier, string item) {
            string sql = "";
            string connString = "<connect info>";
            // If ONLY Location is entered
            if (location != "" && supplier == "" && item == "") {
                MessageBox.Show("Only Location");
                sql = "SELECT " +
                        "      location_id AS 'Location', " +
                        "      supplier_id AS 'Supplier', " +
                        "      item_id AS 'Item', " +
                        "      recommended_qty_to_order AS 'Rec Qty'" +
                        "  FROM PorgReqs  " +
                        "  WHERE location_id = @LocationID " +
                        "  ORDER BY supplier_id, item_id";
                
            }
            // Creates Connection, Sets Variables in Connection and tries to load table
            using (SqlConnection conn = new SqlConnection(connString)) {
                SqlCommand cmd = new SqlCommand(sql, conn);
                // Sets Variable
                cmd.Parameters.AddWithValue("@LocationID", txtLocation.Text);
                // Opens Connection
                conn.Open();
                try 
                {
                    // Creates Reader Object
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    // Fill the list box with the values retrieved
                    if (sqlDataReader.HasRows) {
                        // Create DataTable
                        DataTable dt = new DataTable();
                        // Add Columns to DataTable
                        dt.Columns.Add("Location");
                        dt.Columns.Add("Supplier");
                        dt.Columns.Add("Item");
                        dt.Columns.Add("Rec Qty");
                        dt.Load(sqlDataReader);
                        gridData.DataSource = dt;
                        
                        DataGridViewTextBoxColumn txtAddlQty = new DataGridViewTextBoxColumn();
                        txtAddlQty.Name = "AddlQty";
                        txtAddlQty.HeaderText = "Add'l Qty";
                        txtAddlQty.Width = 75;
                        gridData.Columns.Insert(4, txtAddlQty);
                        DataGridViewTextBoxColumn txtFinalQty = new DataGridViewTextBoxColumn();
                        txtFinalQty.Name = "FinalQty";
                        txtFinalQty.HeaderText = "Final Qty";
                        txtFinalQty.Width = 75;
                        gridData.Columns.Insert(5, txtFinalQty);
                        DataGridViewComboBoxColumn cboAction = new DataGridViewComboBoxColumn();
                        cboAction.Name = "Action";
                        cboAction.HeaderText = "Action";
                        cboAction.Items.AddRange("Buy", "Transfer", "Not Buy");
                        cboAction.Width = 75;
                        gridData.Columns.Insert(6, cboAction);
                        DataGridViewCheckBoxColumn chkApprove = new DataGridViewCheckBoxColumn();
                        chkApprove.Name = "Approve";
                        chkApprove.HeaderText = "Approve";
                        chkApprove.Width = 50;
                        gridData.Columns.Insert(7, chkApprove);
                        
                        gridData.Columns["Location"].Width = 60;
                        gridData.Columns["Supplier"].Width = 60;
                        gridData.Columns["Item"].Width = 125;
                        gridData.Columns["Rec Qty"].Width = 75;
                        
                        // Adds default value to the Action column
                        foreach (DataGridViewRow row in gridData.Rows) {
                            row.Cells["Action"].Value = "Buy";
                        }
                    }
                    
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show(ex.Message);
                }
            }
        } // End Function
