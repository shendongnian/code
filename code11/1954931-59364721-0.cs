    public class OnGooseHonkEvent
    {
        // Calling this will notify every event subscriber the goose has honked
        public void HonkTheGoose()
        {
            OnGooseHonkedEvent?.Invoke(this, EventArgs.Empty);
        }
        public static event EventHandler<EventArgs> OnGooseHonkedEvent;
    }
    public class Class1
    {
        public Class1()
        {
            OnGooseHonkEvent.OnGooseHonkedEvent += OnGooseHonk;
        }
        public void OnGooseHonk(object sender, EventArgs e)
        {
            UntitledGooseAPI.Log("When any instance of OnGooseHonkEvent calls the HonkTheGoose() method, this should get fired");
        }
    }
