    public class EventInvocatorParameters<T>
        where T : EventArgs
    {
        public Func<T, bool> BreakCondition { get; set; }
        // Other properties used below omitted for brevity.
    
        public EventInvocatorParameters<T> Until (Func<T, bool> breakCond)
        {
            this.BreakCondition = breakCond;
            return this;
        }
    }
