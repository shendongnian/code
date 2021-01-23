    private void textBox1_Validating(object sender, 
     				System.ComponentModel.CancelEventArgs e)
    {
       int input = 0;
       bool isNum = Int32.TryParse(textBox1.Text,out input);
       if(!isNum || input < 0 || input > 360)
       {
          // Cancel the event and select the text to be corrected by the user.
          e.Cancel = true;
          textBox1.Select(0, textBox1.Text.Length);
     
       }
    }
