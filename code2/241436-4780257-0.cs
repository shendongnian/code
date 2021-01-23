    // constructor or initializer..
    
    SomeClass.AnotherEvent += (s,e)=>{
       if(MyEvent != null){
          MyEvent(s,e);
       }
    };
    
    // let this be implicit default event
    public event EventHandler MyEvent;
    protected void RaiseMyEvent(){
        if(MyEvent != null){
            MyEvent(this,EventArgs.Empty);
        }
    }
