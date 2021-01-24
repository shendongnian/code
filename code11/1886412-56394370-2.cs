    public static void SendMessage()
    {
        MessageBox.Show("This is a test massage.");
        //And more
    }
    private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
             MainWindow.SendMessage(); 
             //I want run this thread from here
        }
