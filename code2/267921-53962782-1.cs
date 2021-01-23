    bool boolTryAgain = false;
    do
    {
        string sTextFromUser = PopUpBox.GetUserInput("Enter your text below:", "Dialog box title");
        if (sTextFromUser == "")
        {
            DialogResult dialogResult = MessageBox.Show("You did not enter anything. Try again?", "Error", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                boolTryAgain = true; //will reopen the dialog for user to input text again
            }
            else if (dialogResult == DialogResult.No)
            {
                //exit/cancel
                MessageBox.Show("operation cancelled");
                boolTryAgain = false;
            }//end if
        }
        else
        {
            if (sTextFromUser == "cancel")
            {
                MessageBox.Show("operation cancelled");
            }
            else
            {
                MessageBox.Show("Here is the text you entered: '" + sTextFromUser + "'");
                //do something here with the user input
            }
                    
        }
    } while (boolTryAgain == true);
