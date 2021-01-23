    [Flags]
    public enum LowByteReasonValues : byte
    {
        Timer = 1,
        DistanceTravelledExceeded = 2,
        Polled = 4,
        GeofenceEvent = 8,
        PanicSwitchActivated = 16,
        ExternalInputEvent = 32,
        JourneyStart = 64,
        JourneyStop = 128
    }
    
    public readonly LowByteReasonValues LowByte;
    
    public bool Timer 
    {
      get 
      { 
        return (LowByte.HasFlag(LowByte.Timer));
      } 
    }
