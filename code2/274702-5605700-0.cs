    // your validation method accepting the control
    private void ValidateTextBox(TextBox textbox)
    {
      // validation code here
    }
    // bind to click event for button
    private void btnValidate_Click(object Sender, EventArgs e)
    {
      // you can do manual reference:
      List<TextBox> textboxes = new List<TextBoxes>();
      textboxes.AddRange(new[]{
        this.mytextbox,
        this.mysecondtextbox,
        ...
      });
      //---or---
      // Use recursion and grab the textbox controls (maybe using the .Tag to flag this is
      // on you'd like to validate)
      List<TextBox> textboxes = FindTextBoxes();
      //---then---
      // iterate over these textboxes and validate them
      foreach (TextBox textbox in textboxes)
        ValidateTextBox(textbox);
    }
