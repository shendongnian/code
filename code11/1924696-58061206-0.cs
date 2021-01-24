    for(int i = 1; i <= Enum.GetNames(typeof(CardType)).Length; i++)
    {
        CardObject.Type = addCardType(i);
        for(int n =0; n <= 3; n++)
        {
    	     CardObject = new Card();	// Change here
             CardObject.Color = addCardColor(n);
             cardList.Add(CardObject);
        }
    }
