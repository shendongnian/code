    [Parameter]
    public ISpriteSubscriber Subscriber
    {
        get { return subscriber; }
        set 
        {   
            // set the value
            subscriber = value;
            // if the value for HasSubscriber is true
            if (HasSubscriber)
            {
                // Register with the Subscriber so they can talk to each other
                Subscriber.Register(this);
            }
        }
    }
