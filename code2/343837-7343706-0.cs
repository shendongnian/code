    public void ObjectPropertyChanged(DependencyPropertyChangedEventArgs args)
    {
        PropertyChangedEventHandler handler = PropertyChangedEvent;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(args.Property.Name));
        }
    }
