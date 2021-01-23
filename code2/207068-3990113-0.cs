    var selectedCardId = ??;
    
    //Make an array of all the card types (this can be a constant)
    var cardTypes = new CommonHelper.CCType[]{CommonHelper.CCType.Master, CommonHelper.CCType.Visa, CommonHelper.CCType.Express, CommonHelper.CCType.Whatever};
    
    //Loop through, and build the drop-down
    foreach(var card in cardTypes)
    {
    	ddCreditCardType.Items.Add(new ListItem 
    	{ 
    		Value = ((int)card).ToString(), 
    		Text = card.ToString(), 
    		IsSelected = (selectedCardId == (int)card) 
    	});
    }
