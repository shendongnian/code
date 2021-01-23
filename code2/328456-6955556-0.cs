    private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
       // put your validation here.
       if (validations)
       {
          // Display a MsgBox asking the user to continue  or abort.
          if(MessageBox.Show("message...?", "My Application",
             MessageBoxButtons.YesNo) ==  DialogResult.Yes)
          {
             // Cancel the Closing event from closing the form.
             e.Cancel = true;
          }
       }
    }
