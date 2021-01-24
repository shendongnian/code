    private void ValidateGameData(object sender, EventArgs e)
    {
      if (String.IsNullOrWhiteSpace(tbGenre.Text) ||
          String.IsNullOrWhiteSpace(tbTitle.Text) ||
          String.IsNullOrWhiteSpace(tbPrice.Text))
      {
        btnSave.Enabled = false;
      }
      else
      {
        btnSave.Enabled = true;
      }
    }
    tbGenre.TextChanged += ValidateGameData;
    tbTitle.TextChanged += ValidateGameData;
    tbPrice.TextChanged += ValidateGameData;
