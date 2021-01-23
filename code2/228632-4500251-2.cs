    public event EventHandler<EventArgs> Click;
    protected virtual void OnClick()
    {
         if (this.Click !=null)
         {
              this.Click.Invoke(this,EventArgs.Empty);
         }
    }
