    private List<EventHandler> MyHandlers = new List<EventHandler>();
    
    private void MasterClickHandler(object sender, EventArgs e)
    {
       foreach(var handler in MyHandlers)
          handler(sender, e); 
    }
    
    public event EventHandler MyControlButtonClick
    {
       add { MyHandlers.Add(value); }
       remove { MyHandlers.Remove(value); }
    }
    public void InsertButtonClickHandler(EventHandler handler)
    {
       MyHandlers.Insert(handler,0); //calling this to add a handler puts the handler up front
    }
    
    ...
    
    myForm.MyControl.Click += MasterClickHandler;
