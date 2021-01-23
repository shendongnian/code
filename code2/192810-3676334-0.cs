    //web form default.aspx or whatever
    protected override void OnInit(EventArgs e)
    {
        //find the button control within the user control
        Button button = (Button)ucMyControl.FindControl("Button1");
        //wire up event handler
        button.Click += new EventHandler(button_Click);
        base.OnInit(e);
    }
    
    void button_Click(object sender, EventArgs e)
    {
        //send email here
    }
