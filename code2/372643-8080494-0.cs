    if(string.IsNullOrWhiteSpace(lblError.Text))
    {
       lblError.Text = "Please enter last name!";
    }
    else
    {
       lblError.Text += "Please enter last name!" + Environment.NewLine;
    }
