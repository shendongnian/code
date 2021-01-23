    public class CallbackCounter
    {
        protected Int32 Counter { get; set; }        
        public Int32 MaxCount { get; set; }
        public Action Action { get; set; }
        public event EventHandler FinalCallback;
        public CallbackCounter(Action action, Int32 maxCount)
        {
            Action = action;
            Counter = 0;
            MaxCount = maxCount;
        }
        public void Callback()
        {
            Action();
            Counter++;
            if (Counter >= MaxCount)
                RaiseFinalCallback();
        }
        private void RaiseFinalCallback()
        {
            EventHandler temp = FinalCallback;
            if (temp != null)
            {
                temp(this, EventArgs.Empty);
            }
        }
    } 
