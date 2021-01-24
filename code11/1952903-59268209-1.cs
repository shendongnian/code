    if (String.IsNullOrWhiteSpace(tbGenre.Text) ||
        String.IsNullOrWhiteSpace(tbTitle.Text) ||
        String.IsNullOrWhiteSpace(tbPrice.Text)
    {
      MessageBox.Show("Please enter a game genre, game title and game price.");
      return;
    }
    aNewGame[newGameEntryIndex].Title = tbTitle.Text;
    ...
