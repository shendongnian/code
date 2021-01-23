    public void SetValue(ObservableObject owner, TProp value)
    {
       if (!EqualityComparer<TProp>.Default.Equals(Value, value))
       {
           // ... set the property
       }
    }
