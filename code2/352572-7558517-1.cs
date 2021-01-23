    private void Button_Click(object sender, RoutedEventArgs e)
    {
       var newWindow = new AddGame();
       newWindow.DataContext = this.DataContext; // ----> new code to set the DC
       newWindow.Show();
    }
    
    // in the other window...
    private void Button_Click(object sender, RoutedEventArgs e)
    {
      try
      {
         _newGame.Date = date.SelectedDate.Value;
         _newGame.Time = time.Text;
         ((ObservableCollection<Game>)DataContext).Add( _newGame ); // ----> new code
         entity.AddToGames(_newGame);
         entity.SaveChanges();
         this.Close();
      }
      catch (Exception ex) { }
    }
