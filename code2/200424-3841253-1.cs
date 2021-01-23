    public delegate void MyEventHandler(object sender, MyEventArgs e)
    
    public event MyEventHandler MyEvent;
    
    public void RaisesMyEvent()
    {
       ...
       
       if(MyEvent != null) //required in C# to ensure a handler is attached
          MyEvent(this, new MyEventArgs(/*any info you want handlers to have*/));
    }
