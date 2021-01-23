    public partial class UserControl1 : UserControl
    {
        //This is the standard constructor of a user control
        public UserControl1()
        {
            InitializeComponent();
        }
        //This defines an event called "MyCustomClickEvent", which is a generic
        //event handler.  (EventHander is a delegate definition that defines the contract
        //of what information will be shared by the event.  In this case a single parameter
        //of an EventArgs object.
        public event EventHandler MyCustomClickEvent;
        //This method is used to raise the event, when the event should be raised, 
        //this method will check to see if there are any subscribers, if there are, 
        //it raises the event
        protected virtual void OnMyCustomClickEvent(EventArgs e)
        {
            // Here, you use the "this" so it's your own control. You can also
            // customize the EventArgs to pass something you'd like.
            if (MyCustomClickEvent != null)
                MyCustomClickEvent(this, e);
        }
        private void label1_Click(object sender, EventArgs e)
        {
            OnMyCustomClickEvent(EventArgs.Empty);
        }
    }
