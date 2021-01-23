    // TODO: do the same for int.Parse as well
    decimal userDefinedCost;
    if (decimal.TryParse(tbCost.Text, out userDefinedCost))
    {
         comm.AddClientComputer(int.Parse(cbCustomerID.Text), cbAction.Text, userDefinedCOst);
    }
    else
    {
         MessageBox.Show("The cost you have entered is invalid. Please ensure the cost is above 0, and is an actual number", "Invalid Input at Cost", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }
