    private void Button_Click(object sender, RoutedEventArgs e)
    {
       var newWindow = new AddGame();
       newWindow.DataContext = this.DataContext;
       newWindow.Show();
    }
    
    // in the other window...
    private void Button_Click(object sender, RoutedEventArgs e)
    {
      try
      {
         _newGame.Date = date.SelectedDate.Value;
         _newGame.Time = time.Text;
         ((ObservableCollection<Game>)DataContext).Add( _newGame );
         entity.AddToGames(_newGame);
         entity.SaveChanges();
         this.Close();
      }
      catch (Exception ex) { }
    }
