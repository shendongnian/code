    if (String.IsNullOrEmpty(tbGenre.Text) ||
        String.IsNullOrEmpty(tbTitle.Text) ||
        String.IsNullOrEmpty(tbPrice.Text)
    {
      MessageBox.Show("Please enter a game genre, game title and game price.");
      return;
    }
    aNewGame[newGameEntryIndex].Title = tbTitle.Text;
    ...
