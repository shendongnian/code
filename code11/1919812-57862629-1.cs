    //if without a container you must Name your buttons to button1,button2,button3
    int i=0;
    while(true){
      i++;
     Button button = new Button();
     button.Name = "button"+i.toString();//output button1 to n
     WindowsFormName.Controls.Add(button);
    }
    
    private void bbt_Click(object sender, RoutedEventArgs e)
    {
      
      //loop all controls
      int y=0;
      foreach(Control control in WindowsFormName.Controls){
      y++;
      string name = "Button"+y.toString();
        //check if names are button1 or buttonN
      if(control.Name.Equals(name){
            control.Content = "TEST";
        }
       }
     
    }
