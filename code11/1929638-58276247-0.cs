    /// <summary>
    /// Initializes a new instance of the ThumbnailCard class.
    /// </summary>
    /// <param name="title">Title of the card</param>
    /// <param name="subtitle">Subtitle of the card</param>
    /// <param name="text">Text for the card</param>
    /// <param name="images">Array of images for the card</param>
    /// <param name="buttons">Set of actions applicable to the current
    /// card</param>
    /// <param name="tap">This action will be activated when user taps on
    /// the card itself</param>
    public ThumbnailCard(string title = default(string), string subtitle = default(string), string text = default(string), IList<CardImage> images = default(IList<CardImage>), IList<CardAction> buttons = default(IList<CardAction>), CardAction tap = default(CardAction))
    {
        Title = title;
        Subtitle = subtitle;
        Text = text;
        Images = images;
        Buttons = buttons;
        Tap = tap;
        CustomInit();
    }
