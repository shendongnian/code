    private void btnSave_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(tbGenre.Text))
        {
            MessageBox.Show("please enter a Game genre.");
        }
        else if (String.IsNullOrEmpty(tbTitle.Text))
        {
            MessageBox.Show("please enter a Game title");
        }
        else if (String.IsNullOrEmpty(tbPrice.Text))
        {
            MessageBox.Show("please enter a Game price");
        }
        else
        {
            // You forgot to create the new game at this index
            aNewGame[newGameEntryIndex] = new Game();
            aNewGame[newGameEntryIndex].Title = tbTitle.Text;
            aNewGame[newGameEntryIndex].Genre = tbGenre.Text;
            aNewGame[newGameEntryIndex].Price = Convert.ToDecimal(tbPrice.Text);
            newGameEntryIndex++;
            MessageBox.Show("entry saved");
            //clears the text boxes 
            tbTitle.Clear();
            tbGenre.Clear();
            tbPrice.Clear();
        }
    }
