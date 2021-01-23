    public event EventHandler CustomEvent;
    
    protected virtual void OnCustomEvent(EventArgs e) 
    {
         if(CustomEvent != null) 
         {
             CustomEvent(this, e);
         }
    }
    
    protected override void OnPreRender(EventArgs e)
    {
         OnCustomEvent(new EventArgs());
         base.OnPreRender(e);
    }
