    private DateTime _LastExecution = DateTime.MinValue;
    public void UserControl_KeyDown(object sender, EventArgs ea) {
        if ( ( DateTime.Now - _LastExecution ).TotalMilliSeconds > 500 ) {
            /* do you stuff */
            _LastExecution = DateTime.Now;
        }
    }
