    Activity IActivityTemplateFactory.Create(System.Windows.DependencyObject target)
    {
        return new Trigger 
        {
            DisplayName = "lol trigger",
            Condition = new ActivityFunc<bool>(),
            Child = new ActivityAction(),
            MatchType = MatchType.Lol
        };
    }
