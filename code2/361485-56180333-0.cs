    private delegate void _deleSetMesssage(string msg);
    
    public void SetMessage(string msg)
    {
        if (this.InvokeRequired)
        {
           _deleSetMesssage method = new _deleSetMesssage(SetMessage);
           this.Invoke(method, new object[] { msg });
        }
        else
        {
            this.label1.Text = msg;
        }
    }
