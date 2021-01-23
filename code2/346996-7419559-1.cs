    protected Action<object,EventArgs> myClickAction = (s, a) => { /* your handling code goes here */ };
    
    ...
    protected void Page_Load(object sender, EventArgs e)
    {    
        myUserControlName.onMyButtonClick = myClickAction;
    }
    ...
    
    void btn_Click(object sender, EventArgs e)
    {
        myClickAction(sender, e);
    }
