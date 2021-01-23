    static StupidBehavior()
    {
        handlerDictionary[IsEnabledProperty] = (o,e) => MyMethod();
        handlerDictionary[SomeOtherProperty] = (o,e) => SomeOtherMethod();
    }
    private static void CommonPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        var uie = sender as UIElement;
        if (uie != null)
        {
            //removing before possibly adding makes sure the multicast delegate only has 1 instance of this delegate
            sender.MouseDown -= handlerDictionary[args.Property];
            if (args.NewValue != null)
            {
                sender.MouseDown += handlerDictionary[args.Property];
            }
        }
    }
