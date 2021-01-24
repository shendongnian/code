    DatabaseUtils databaseUtils;
    async void Start()
    {
        databaseUtils = new DatabaseUtils();
		Ally ally = new Ally("card name 12", "card description 12", CardType.Ally, 20, 30);
        databaseUtils.AddCard(ally);
        await databaseUtils.ReadCard();
        Debug.Log(databaseUtils.GetCard().CardName);
    }
