    class MyGame
    {
        private readonly static random = new Random();
        public MyGame()
        {
            this.MagicNumber = this.random.Next(1, 10);
            this.GuessCount = 0
        } 
        public TextBox Messagebox {get; set;}     // shows higher / lower / ok
        public Control ColorControl {get; set;}   // Change the color when almost out of guesses
        public int MagicNumber {get; private set;}
        public int GuessCount {get; private set;}
         
        public void Guess(int guess)
        {
            // update the MessageBox:
            if (guess > this.MagicNumber)
                this.MessageBox.Text = ...
            else if (guess < this.MagicNumber)
                this.MessageBox.Text = ...
            else
                this.MessageBox.Text = ...
            // update the backgound color:
            ++this.GuessCount;
            if (this.GuessCount < ...)
               this.ColorControl.BackColor = ...
            else if (this.GuessCount < ...)
               this.ColorControl.BackColor = ...
            // etc.
        }
    }
