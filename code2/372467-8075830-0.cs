    var dialogForm = new MyNewForm();
    if (dialogForm.ShowDialog() != DialogResult.OK)
    {
       Application.Exit()
    }
    else 
    {
       var pw = dialogForm.GetText(); // string var pw stores the enterd pw now
       // validate your password here
  
       if (PasswordIsCorrect())
       {
          // some logic here
       } 
    }
