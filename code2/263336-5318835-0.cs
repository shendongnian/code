    public InvalidNumberException(int value)
    {
       var message = string.Format("Some custom error message. Value: {0}", value);
       base(message, this.InnerException)
    }
