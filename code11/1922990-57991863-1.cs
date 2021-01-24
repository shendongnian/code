    public ActionResult Add(int cardId,int deckId)
    {
        using (YourSolution.YoueProjectName.Models.EntitiesDB db=new EntitiesDB())
        {
         DeskCard d=new DeskCard();
         d.Card_Id=cardId;
         d.Deck_Id=deckId;    
         db.DeckCard.Add(d)//Or AddObject() basesd on version
         db.SaveChanges();
         }
       }
    }
