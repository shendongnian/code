    var Cards = new List<Card>();
        
    if (Sprint_ID == null)
    {
        Cards = db.Cards.Where(x => x.State_ID == State_ID &&
                                    x.Sprint_ID == null &&
                                    x.Deleted != 1 &&
                                    x.Archive != 1).ToList();
    }
    else
    {
        Cards = db.Cards.Where(x => x.State_ID == State_ID &&
                                    x.Sprint_ID == Sprint_ID &&
                                    x.Deleted != 1 &&
                                    x.Archive != 1).ToList();
    }
