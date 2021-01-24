    IEnumerable<AdaptiveCard> cards;    
    await context.Context.SendActivityAsync((Activity)MessageFactory.Carousel(cards.Select(c => new Attachment
                        {
                            ContentType = AdaptiveCard.ContentType,
                            Content = c,
                        })));
