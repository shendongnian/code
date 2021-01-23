    private void btnAddClientComputer_Click(object sender, EventArgs e)
    {
        SQLCommands comm = new SQLCommands();
        double trycost;
        if (double.TryParse(tbCost.Text,out trycost))
        {
            comm.AddClientComputer(int.Parse(cbCustomerID.Text), cbAction.Text, trycost);
        }
        else
        {
            MessageBox.Show("The cost you have entered is invalid. Please ensure the cost is above 0, and is an actual number", "Invalid Input at Cost", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
...
    
    public void AddClientComputer(int CustomerID, string Action, double Cost)
        {
            try
            {
                comm = new SqlCommand("UspAddClientComputer", conn); // Stored Procedure - see sql file
                comm.Parameters.AddWithValue("@CustomerID", CustomerID);
                comm.Parameters.AddWithValue("@Action", Action);
                comm.Parameters.Add(new SqlParameter("@Cost",Cost));
                comm.CommandType = CommandType.StoredProcedure;
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
