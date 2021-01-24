    private bool ValidateInputs()
        {
            if (txtBox_eventName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter a valid event name", "Action Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBox_eventName.Focus();
                return false;
            }
            if (nud_noOfGuests.Value < 10 || nud_noOfGuests.Value > 200)
            {
                MessageBox.Show("Please enter no of guests between 10 and 200", "Action Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (radBtn_primeRib.Checked == false && radBtn_chickenMarsala.Checked == false && radBtn_gardenLasagna.Checked == false)
            {
                MessageBox.Show("Please make an Entree choice", "Action Reuired", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
