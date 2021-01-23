    protected override void CreateChildControls()
    {
        var ctlMyControl = new MyControl();
    
        ctlMyConstrol += SuccessCode;
    
        this.Control.Add(ctlMyControl);
    }
    
    protected void SuccessCode(object sender, EventArgs e)
    {
        //DO SOMETHING
    }
