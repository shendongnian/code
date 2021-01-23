    protected void cvName_ServerValidate(object source, ServerValidateEventArgs args)
    {
      if (myDDL.SelectedItem == "" && myTB.Text == "") //If nothing is selected in the drop down AND the text box is blank...
      {
        args.IsValid = false; // Set the validator to false
      }
    }
