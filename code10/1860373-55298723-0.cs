           for (int c = 1; c < 5; c++)
            {
                Card card = new Card();
                {
                    card.Suite = c;
                }
Then, after each of those 4 cars are created, you are changing their value 13 times:
                Card card = new Card();
                { /*...*/ }                }
                for (int k = 1 ; k <=13; k++)
                {
                    card.Value = k;
                    // ... 
                }
