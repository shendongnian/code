    Activity IActivityTemplateFactory.Create(System.Windows.DependencyObject target)
    {
        return new Trigger()
        {
            Child = new ActivityAction()
            {
                DisplayName = "Trigger Child Action"
            },
            Condition = new ActivityFunc<bool>()
            {
                DisplayName = "Trigger Conditionals"
            },
            DisplayName = "Trigger"
        };
    }
