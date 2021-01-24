           for (int c = 1; c < 5; c++)
            {
                Card card = new Card();
                {
                    card.Suite = c;
                }
Then, after each of those 4 cars are created, you are adding *the same* card instance 13 times. You are also changing the value of that instance 13 times so you'll end up with a `Deck` with 13 instances of the same card object (all of them being Kings):
                Card card = new Card();
                { /*...*/ } 
                for (int k = 1 ; k <=13; k++)
                {
                    card.Value = k;
                    // ... 
                    Deck.Add(card);
                }
To solve your problem you have to create each card inside the for "values" loop:
           for (int c = 1; c < 5; c++)
           {
                for (int k = 1 ; k <=13; k++)
                {
                     Card card = new Card();
                     // ... Set here the Value and Suite
                 }
            }
