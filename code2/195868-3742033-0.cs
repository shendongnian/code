    public class MyEventArgs: EventArgs
    {
      ...
    }
    
    public delegate void MyEventHandler(object sender, MyEventArgs e);
    
    public class MyControl: UserControl
    {
      public event MyEventHandler MyEvent;
       ...
    }
