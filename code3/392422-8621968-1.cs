    //the custom command
    public static RoutedCommand AddToBox = new RoutedCommand();
    //add the can execute method
    private void AddToBox_CanExecute(sender object, CanExecuteRoutedEventArgs e)
    {
        //assuming that this can always execute
        e.CanExecute = true;
    }
    
    //Executing the command when the button is clicked
    //Show the dialog box and get the response
    private void AddToBox_Executed(sender object, ExecutedRoutedEventArgs e)
    {
         PopUpBox dialog = new PopUpBox();
         var result = dialog.ShowDialog();
         if (result == true)
         {
              string box = e.Parameter;      
    
              //get the result of the dialog where GetResult() is the
              //method that returns the necessary information.
              //here set to object for the sake of example
              object[] obj = dialog.GetResult()
              switch (box)
              {
                   case "box1":
                        //put value into box 1
                   case "box2":
                        //put value into box 2
                   case "box3":
                        //put value into box 3
              }
         }
    }
