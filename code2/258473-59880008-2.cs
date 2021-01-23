    public class MyViewModel 
    {
      ICommand buttonCommand;
      /// <summary>
      /// Command for Button.
      /// Default action is close the window.  
      /// Close window via retyping parameter as <see cref="IClosable"/> 
      /// </summary>
      public ICommand ButtonCommand => buttonCommand ?? (buttonCommand=new RelayCommand(ButtonCommandExecute));
      void ButtonCommandExecute (object obj) 
      {
          var myWindow = (IClosable)obj;
          myWindow.Close();
      };
  
