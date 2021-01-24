    private Form1 myForm = new Form1(); //Declare the form as a private member variable
    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
        e.Cancel = true;       //Cancel the closing so this object stays alive
        this.Visible = false;  //Hide this form
        myForm.Show();         //Show the next form
    }
