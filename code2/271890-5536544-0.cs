    public event EventHandler<EventArgs> Clicked3Times;
    protected virtual void OnClicked3Times()
    {
         var handler = this.Clicked3Times;
         if (handler != null) 
         {
             handler(this,EventArgs.Empty);
         }
    }
