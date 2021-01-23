    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Button button = sender as Button;
        Game game = button.DataContext as Game;
        int id = game.ID;
        // ...
    }
