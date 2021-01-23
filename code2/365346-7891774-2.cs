    //Please don't do this.
    
    private EventHandler myEventField = delegate { };
    
    // Add synchronization if required.
    public event EventHandler MyEvent
    {
       add
       {
          if(value.Target is IPerson)
            myEventField += value;
    
          else throw new ArgumentException("Subscriber must implement IPerson", "value");
       }
    
       remove { myEventField -= value; }
    }
    private void RaiseMyEvent() { myEventField(this, EventArgs.Empty); }
