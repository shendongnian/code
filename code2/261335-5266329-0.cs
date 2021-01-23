        int pin;
        int i;  
        
        pin = Convert.ToInt32(txtbox.Text);             
        if (pin !=21)
        {
            MessageBox.Show ("Fail. " + i + " attempts more.", "EPIC FAIL",                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            counter += 1;
            if (counter = 3)
                {                       
                    Application.Exit();
                }
        }
        else
        {
            MessageBox.Show ("Welcome. Your pin is CORRECT", "CONGRATULATIONS",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
