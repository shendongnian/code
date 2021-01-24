    private void Button_Click(object sender, RoutedEventArgs e)
    {
      var result = new StringBuilder(1000);
      //we are creating a new instance 
      //outside of the for loop     
      var rand = new Random();
      for(int i = 0; i < 10; i++)
      {                
        result.AppendLine(rand.Next().ToString());
      }
      //no duplicates
      //the problem is now fixed
      MessageBox.Show(result.ToString());
    }
