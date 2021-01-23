            //Checking validation for the text boxes
            bool isValid = true;
            if (string.IsNullOrEmpty((txtFirstName.Text ?? string.Empty).Trim()))
            {
                txtFirstName.BackColor = System.Drawing.Color.Yellow;
                lblError.Text += "Please enter first name! <br />";
                isValid = false;
            }
            if (string.IsNullOrEmpty((txtLastName.Text ?? string.Empty).Trim()))
            {
                txtLastName.BackColor = System.Drawing.Color.Yellow;
                lblError.Text += "Please enter last name! <br />";
                isValid = false;
            }
            // etc.
