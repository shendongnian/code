    private int attemptsLeft = 3;
    
    private void btnEtr_Click(object sender, System.EventArgs e)
        {
            int pin = Convert.ToInt32(txtbox.Text);             
    
            if (pin !=21)
            {
                    MessageBox.Show ("Fail. " + --i + " attempts more.", "EPIC FAIL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  
                  if( attemptsLeft == 0 )
                  {
                       Application.Exit();
                  }
            }
            else
            {
                MessageBox.Show ("Welcome. Your pin is CORRECT", "CONGRATULATIONS",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
