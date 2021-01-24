    var data = new List<string> { "Swiss cargo", "ticket booking" };
    var card = new AdaptiveCard()
    {
        Body = new List<CardElement>()
        {
            new TextBlock()
            {
                Color = TextColor.Attention,
                Weight = TextWeight.Bolder,
                Size = TextSize.Medium,
                Text = "Select a title",
            },
            new ChoiceSet()
            {
                Id = "title",
                Style = ChoiceInputStyle.Compact,
                IsRequired = false,
                IsMultiSelect = false,
                Value = "1",
                Choices = data.Select(item => new Choice { Title = item, Value = item }).ToList(),
            },
        },
    };
