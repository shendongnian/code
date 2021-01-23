    public interface IEventData
    {
        ErrorReaction Reaction { get; }
        string Message { get; }
        ComponentName { get; }
    }
    public class HardwareChangeEventData : IEventData
    {
        public HardwareChangeEventData(ErrorReaction reaction, string msg, string componentName)         
        {             
            Reaction = reaction;             
            Message = msg;             
            ComponentName = componentName;         
        }
        public ErrorReaction Reaction { get; private set; }
        public string Message { get; private set; }
        public ComponentName { get; private set; }
    }
    ....
    // introduce a base class so all hardware components can raise the event
    public class HardwareComponent    
    {
        public delegate void HardwareChangedEventHandler(IEventData ed);
        public event HardwareChangedEventHandler HardwareChanged;
        //event-invoking method that derived classes can override.
        protected virtual void OnHardwareChanged(IEventData ed)
        {
            HardwareChangedEventHandler handler = HardwareChanged;
            if (handler != null)
            {
                handler(this, ed);
            }
        }
    }
    public class TemperatureGauge : HardwareComponent
    {
        public void Monitor()
        {
             // example logic
             while (...)
             {
                 if (Temperature < LowThreshold)
                 {
                      IEventData ed = new HardwareChangeEventData(ErrorReaction.IncreaseTemp, "Temperature too low!", "TemperatureGauge");
                      OnHardwareChanged(ed);
                 } 
             }
        }
        public override OnHardwareChanged(IEventData ed)
        {
            // do something with ed internally (if applicable)
            // forward event on to base so it can be passed out to subscribers
            base.OnHardwareChanged(ed);
        }
    }
