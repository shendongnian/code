    protected override void OnLeave(EventArgs e)
    {
       // Call the base class
       base.OnLeave(e);
    
       // When this control loses the focus, close it
       this.Hide();
    }
