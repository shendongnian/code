    private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (MessageBox.Show("This will close down the whole application. Confirm?", "Close Application", MessageBoxButtons.YesNo) != DialogResult.Yes)
        {
            e.Cancel = true;
        } 
        //If mainForm isn't the main form, then you need the else statement below
        else
        {
            System.Windows.Forms.Application.Exit(); 
        }
    }
