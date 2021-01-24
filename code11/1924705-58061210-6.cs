    for(int i = 1; i <= Enum.GetNames(typeof(CardType)).Length; i++)
    {
        CardObject.Type = addCardType(i);         // Sets Card Type
        for(int n =0; n <= 3; n++)
        {
            CardObject.Color = addCardColor(n);   //1. Sets Color on THE SAME CardObject
            cardList.Add(CardObject);             //2. Adds THE SAME CardObject 4 times
        }
        CardObject = new Card();                  //3. create new Object => all of the 
                                                  // above added references point to
                                                  // the same CardObject, which has 
                                                  // been set to "Red".
    }
