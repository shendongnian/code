    public bool TradingTime()
    {                        
        TimeSpan CurrentTime = DateTime.Now.TimeOfDay;
        return ((CurrentTime > StartingTime) && (CurrentTime < EndingTime));            
    }
