    protected void SomeControl_Clicked(object sender, EventArgs e)
    {
        //Here cast the sender to the type of control you made:
        SomeControl ctrl = (SomeControl)sender;
        string byId = ctrl.ArrangeById;
        string val = ctrl.Value;
    }
