    private void Button_Click(object sender, RoutedEventArgs e)
    {
      var result = new StringBuilder(1000);
      for(int i = 0; i < 10; i++)
      {
        //we are creating a new instance 
        //every single iteration
        //this means all these instances
        //have the same 'seed'
        var rand = new Random();
        result.AppendLine(rand.Next().ToString());
      }
      //produces a lot of duplicates
      MessageBox.Show(result.ToString());
    }
