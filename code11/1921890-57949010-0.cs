    if( string.IsNullOrWhiteSpace( textBox_Name.Text ))
    {
       MessageBox.Show("You have not entered a value for the name");
       return;
    }      
    
    if( textBox_Name.Text.Equals( "something", StringComparison.CurrentCultureIgnoreCase )
    {
       string message = "Your name is not " + textBox_Name.Text;
       string caption = "Error input";
       MessageBoxButtons buttons = MessageBoxButtons.RetryCancel;
       MessageBox.Show(message, caption, buttons);
       textBox_Name.Clear();
       return;
    }
    
    // else, must have had something valid other than empty or "something" regardless of case.
    MessageBox.Show("Good job something you know your name, LOL");
