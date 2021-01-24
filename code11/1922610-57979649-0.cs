    @Html.ActionLink($"Add to: {d.Name} ", "Add", new { cardId = Model.Cards.Id, deckId = d.id })
...
    public ViewResult Add(int cardId, int deckId)
    {
        var cardInDb = _context.Cards.Single(c => c.Id == cardId);
        var deckInDb = _context.Decks.Single(d => d.id == deckId);
        deckInDb.Card.Add(cardInDb);
        cardInDb.Deck.Add(deckInDb);
        return View("Index");
    }
