    class Program
    {
        static void Main(string[] args)
        {
            bool retry = false;
            do
            {
                // start of game
                bool gameOver = false;
                int turn = 3;
                do
                {
                    // game here
                    // set gameOver when guess is corrent
                    turn--;
                } while (turn>0 && !gameOver);
                // post game scores
                // ask to retry
            } while (retry);
            // end here
        }
    }
