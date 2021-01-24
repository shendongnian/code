    Public Class Login
    {
     //If Username or Password Web Elements are not found in UI or the Search 
     //Property is modified the Constructor fails and execution stops. How to avoid the failure.
      public Login()
      {
       try
       {
        UsernameTextBox = Driver.FindElement(By.Name('User'));
       }
       catch(NoElementFoundException e)
       {UsernameTextBox  = null;}
       try
       {
       PasswordTextBox = Driver.FindElement(By.Name('Pwd'));
       }
       catch(NoElementFoundException e)
       {PasswordTextBox = null;}
      }
      public IWebElement UsernameTextBox { get; } 
      public IWebElement PasswordTextBox { get; } 
    }
