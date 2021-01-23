    protected Action<object,EventArgs> myClickAction = (s, a) => { /* your handling code goes here */ };
    
    ...
    protected void Page_Load(object sender, EventArgs e)
    {    
        myUserControlName.onMyButtonClick = myClickAction;
        btn.Click += (s,ea) => { myClickAction(s,ea); };
    }
