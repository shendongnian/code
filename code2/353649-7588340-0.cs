      img1.Command += ImageButton_OnCommand;
      protected void ImageButton_Command(object sender, CommandEventArgs e) 
      {
         if (e.CommandName == "Sort" && e.CommandArgument == "Ascending")
            Label1.Text = "You clicked the Sort Ascending Button";
         else
            Label1.Text = "You clicked the Sort Descending Button";
      }
