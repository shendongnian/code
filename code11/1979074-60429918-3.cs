     public IMessageActivity OverViewFlow()
            {
                try
                {
                    var replyToConversation = Activity.CreateMessageActivity();
                    replyToConversation.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                    replyToConversation.Attachments = new List<Attachment>();
    
                    Dictionary<string, string> cardContentList = new Dictionary<string, string>();
                    cardContentList.Add("Link 1", "https://via.placeholder.com/300.png/09f/fffC/O");
                    cardContentList.Add("Link 2", "https://via.placeholder.com/300.png/09f/fffC/O");
                    cardContentList.Add("Link 3", "https://via.placeholder.com/300.png/09f/fffC/O");
    
                    foreach (KeyValuePair<string, string> cardContent in cardContentList)
                    {
                        List<CardImage> cardImages = new List<CardImage>();
                        cardImages.Add(new CardImage(url: cardContent.Value));
    
                        List<CardAction> cardButtons = new List<CardAction>();
    
                        CardAction plButton = new CardAction()
                        {
                            Value = $"",
                            Type = "imBack",
                            Title = "" + cardContent.Key + ""
                        };
    
                        cardButtons.Add(plButton);
    
                        HeroCard plCard = new HeroCard()
                        {
                            Title = $"",
                            Subtitle = $"",
                            Images = cardImages,
                            Buttons = cardButtons
                        };
    
                        Attachment plAttachment = plCard.ToAttachment();
                        replyToConversation.Attachments.Add(plAttachment);
                    }
    
                    return replyToConversation;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException(ex.Message, ex.InnerException);
                }
            }
