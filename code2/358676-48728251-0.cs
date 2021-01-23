    //it is a good idea to use the 'sender' object when calling the form load method 
    //because doing so will let you determine if the sender was a button click or something else...
  
    private void button2_Click(object sender, EventArgs e)
    {
        Form1_Load(sender, e);
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
        if (sender is Button)
        {
             //the message box will only show if the sender is a button
             MessageBox.Show("You Clicked a button");
        }
    }
