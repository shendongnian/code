      protected void LinkButton_Click(Object sender, EventArgs e) 
      {
         string commandArgument = (sender as LinkButton).CommandArgument;
         string commandName =(sender as LinkButton).CommandName;
        if(commandName == "something")
        {
            //Do something
           //and so on
        }
      }
