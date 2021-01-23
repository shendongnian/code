    private void Form1_Load(object sender, EventArgs e)
    {
       this.Close();  //this will call Form_Closing()
    }
    private void Form1_Closing(object sender, EventArgs e)
    {
        //do stuff
        if (result == DialogResult.No)
        {
              e.Cancel = true;        // if you don't want to close your form 
        }
        else
        {
            // do stuff on closing form
        }
    }
    
