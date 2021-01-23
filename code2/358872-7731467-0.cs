        public event EventHandler<UpdatedEventArgs> updateEvent;
        public class UpdatedEventArgs : EventArgs
        {
            public string SomeVal { get; set; } // create custom event arg for your need
        }
        protected virtual void OnFirstUpdateEvent(UpdatedEventArgs e)
        {
            if (updateEvent != null)
                updateEvent(this, e);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            UpdatedEventArgs eventData = new UpdatedEventArgs(); 
            eventData.SomeVal = "test"; // set update event arguments, according to your need
            OnFirstUpdateEvent(eventData);
        }
        public Form2()
        {
            InitializeComponent();
        }
