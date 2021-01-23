    void ValidateBtn_OnClick(object sender, EventArgs e) 
      { 
         // Display whether the page passed validation.
         if (Page.IsValid) 
         {
            Message.Text = "Page is valid.";
         }
         else 
         {
            Message.Text = "Page is not valid!";
         }
      }
      void ServerValidation(object source, ServerValidateEventArgs args)
      {
         try 
         {
            // Test whether the value entered into the text box is even.
            int i = int.Parse(args.Value);
            args.IsValid = ((i%2) == 0);
         }
         catch(Exception ex)
         {
            args.IsValid = false;
         }
      }
