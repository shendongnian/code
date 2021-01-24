    private MyGame game = null;
    void StartNewGame()
    {
        this.game = new MyGame();
        this.game.MessageBox = this.lblCond;  // the text box for messages.
        this.game.ColorControl = this; // the complete form changes color after a few guesses
    }
