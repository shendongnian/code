     public event EventHandler TestEvent;
    protected void Page_Load(object sender, EventArgs e)
    {
       if (this.TestEvent != null)
           {
               this.TestEvent(this, e);
           }
    }
