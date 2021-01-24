    public async Task ReadCard()
    {
        await FirebaseDatabase.DefaultInstance.GetReference("Cards").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
               
            }
            else if (task.IsCompleted)
            {
                DataSnapshot dataSnapshot = task.Result;
                var json = dataSnapshot.Child("P001-0000-0001").GetRawJsonValue();
                Ally card = JsonUtility.FromJson<Ally>(json);
                Debug.Log(card.CardDescription);
                Debug.Log(card.CardName);
                Debug.Log(card.CardType);
                Ally ally = new Ally(card.CardName, card.CardDescription, card.CardType, card.Atk, card.Hp);
                SetCard(ally);
            }
        });
    }
    public void SetCard(Card card)
    {
        this.card = card;
    }
    public Card GetCard()
    {
        return card;
    }
