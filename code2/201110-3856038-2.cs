    protected override void CreateChildControls()
    {
        var ctlMyControl = new MyControl();
    	  //Subscribed to the newly added event of your MyControl class
    		ctlMyControl.Submit_OnClick += new EventHandler(SuccessCode);
    
        //ADD SuccessCode() TO ctlMyControl
        //SO IT IS TRIGGERED ON SUCCESS
        //MAYBE SOMETHING LIKE:
        //ctlMyControl.SuccessEvent = SuccessCode()??
    
        this.Control.Add(ctlMyControl);
    }
    
    //Modified the signature to be compliant with EventHandler type
    protected void SuccessCode(object sender, EventArgs e)
    {
        //DO SOMETHING
    }
