    public class HandleHookedListView: ListView
    {
        private EventHandler _handleCreatedEvent;
        public HandleHookedListView(): base()
        {
            _handleCreatedEvent = new EventHandler(HandleHookedControl_HandleCreated);
            this.HandleCreated += _handleCreatedEvent;
        }
        private bool _handleIsCreated;
        public bool HandleIsCreated
        {
            get { return _handleIsCreated; }
            set { _handleIsCreated = value; }
        }
        void HandleHookedControl_HandleCreated(object sender, EventArgs e)
        {
            Debug.Print("Handle Created");
            this.HandleIsCreated = true;
            
            // Unhook the delegate
            if (_handleCreatedEvent != null)
                this.HandleCreated -= _handleCreatedEvent;
        }
    }
