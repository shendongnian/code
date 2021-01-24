    protected void LinkButton1_Click(object sender, System.EventArgs e)
    {
     LinkButton lnkButton = (LinkButton)sender;
     string[] args = lnkButton.CommandArgument.Split(';');
    
     string name = string.Empty, userId = string.Empty;
     if (args.Length == 2)
     {
       name = args[0];
       userId = args[1];
     }
    }
