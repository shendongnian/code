    internal static IMessageActivity CreateBattleshipCardActivity(
        string cardId,
        object data = null)
    {
        data = data ?? new
        {
            name = "Test shot",
            shoots = new string[0],
        };
        JObject card = CreateAdaptiveCard("battleship", data);
        foreach (var token in card.Descendants()
            .Select(token => token as JProperty)
            .Where(token => token?.Name == KEYCARDID))
        {
            token.Value = cardId;
        }
        return MessageFactory.Attachment(new Attachment(
            AdaptiveCard.ContentType,
            content: card));
    }
