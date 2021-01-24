    public void Start()
    {
        this.Timer = new Timer();
        this.Timer.Interval = this.interval;
        this.Timer.Elapsed += Timer_Elapsed;
        this.Timer.Start();
    }
    private void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        // if a subscriber (returns true if Subscriber != null)
        if (HasSubscriber)
        {
            // Notify Subscriber
            Subscriber.Refresh();
        }
    }
    public void Refresh()
    {
        // do your actions here
    }
    public void Register(Sprite sprite)
    {
        // If the sprite object exists
        if (NullHelper.Exists(sprite))
        {
            // if this is the RedCar
            if (sprite.Name == "RedCar")
            {
                // Set the RedCar
                RedCar = sprite;
            }
            else 
            {
                // Set the WhiteCar
                WhiteCar = sprite;
            }
        }
    }
