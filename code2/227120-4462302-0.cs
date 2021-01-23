    //Define your Custom Event argument
    public class MyEventArgs : EventArgs
    {
        //Define some fields of your custom event argument
        private int m_SomeValue = 0;
        //Define some properties of your custom event argument
        public int SomeValue
        {
            get { return m_SomeValue; }
            set { m_SomeValue = value; }
        }
    }
    //Define the event handler data type
    public delegate void MyEventHandler(object sender, MyEventArgs e);
    //Define the object which holds the outside event handlers
    public event MyEventHandler SomeEvent;
    //Define the function which will generate the event
    public virtual void OnSomeEvent(MyEventArgs e)
    {
        if (SomeEvent != null)
            SomeEvent(this, e);
    }
    .
    . //Then later in the control
    .
    {
        //We need new data
        
        //Create the event arguments
        MyEventArgs newEvent = new MyEventArgs();
        
        //Set the values
        newEvent.SomeValue = 17;
        //Call the event generating function
        OnSomeEvent(newEvent);
    }
