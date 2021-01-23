    // Simple class to host the Event
    class Test
    {
      public event EventHandler MyEvent;
    }
    // Two different methods which will be wired to the Event
    static void MyEventHandler1(object sender, EventArgs e)
    {
      throw new NotImplementedException();
    }
    static void MyEventHandler2(object sender, EventArgs e)
    {
      throw new NotImplementedException();
    }
    
    [STAThread]
    static void Main(string[] args)
    {
      Test t = new Test();
      t.MyEvent += new EventHandler(MyEventHandler1);
      t.MyEvent += new EventHandler(MyEventHandler2); 
      // Break here before removing the event handler and inspect t.MyEvent
      
      t.MyEvent -= new EventHandler(MyEventHandler1);      
      t.MyEvent -= new EventHandler(MyEventHandler1);  // Note this is again MyEventHandler1    
    }
