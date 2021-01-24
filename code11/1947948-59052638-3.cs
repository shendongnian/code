    void OnButtonGuessClicked(Button sender, EventArgs e)
    {
         if (Object.ReferenceEquals(sender, this.ButtonGuess)
         {    // User pressed guess button
              string input = this.ButtonGuess.Text;
              int guess = Int32.Parse(input);
              // TODO: catch exception and proper error if not a proper number
              this.Game.Guess(guess);
              // this will display the result and color the form
          }
     }
