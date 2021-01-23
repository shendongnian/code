     private MainWindow window;
     public MessageWindow(MainWindow mainWindow)
            {
                InitializeComponent();
                window = mainWindow;
            }
       //now handle the click event of yes and no button
      private void YesButton_Click(object sender, RoutedEventArgs e)
            { 
                //close this window
                this.Close();
                //pass true in case of yes
                window.GetResult(true);
            }
    
            private void NoButton_Click_1(object sender, RoutedEventArgs e)
            {
                //close this window
                this.Close();
                //pass false in case of no
                window.GetResult(false);
            }
     //in that case you will show the popup window like this
     MessageWindow message= new MessageWindow(this);
     message.ShowDialog();
