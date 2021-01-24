    If(string.IsNullOrEmpty(textbox1.Text) 
       && string.IsNullOrEmpty(textbox2.Text)
       && string.IsNullOrEmpty(textbox3.Text))
    {
         Messagebox.Show("You need to fill all fields in");
    }
    else
    {
         Messagebox.Show("You have successfully registered");
    }
