    //--> here come some more logic im not sure About:
    TimeSpan DurationHours 
    { 
        get => Duration.Hours;
        set 
        {
            // set only Hours componennt of Duration
            Duration = Duration
                .Subtract(Duration.Hours)
                .Add(value);
            NotifyPropertyChanged();
        }
    
    TimeSpan DurationMinutes 
    { 
        get => Duration.Minutes;
        set 
        {
            // set only Minutes componennt of Duration
            Duration = Duration
                .Subtract(Duration.Minutes)
                .Add(value);
            NotifyPropertyChanged();
        }
