     try
        {
            comm.AddClientComputer(int.Parse(cbCustomerID.Text), cbAction.Text, decimal.Parse(tbCost.Text));
        }
        catch (FormatException)
        {
            MessageBox.Show("The cost you have entered is invalid. Please ensure the cost is above 0, and is an actual number", "Invalid Input at Cost", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
