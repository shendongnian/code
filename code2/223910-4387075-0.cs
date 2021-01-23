    public event EventHandler<EventArgs> SearchClicked;
    protected virtual void OnSearchClicked()
    {
         if (this.SearchClicked != null)
         {
             this.SearchClicked.Invoke(this,EventArgs.Empty);
         }
    }
