    private bool _changeByCode;
    public void DoSomeChanges()
    {
        _changeByCode = true;
        textbox1.Text = "Hello";
        _changeByCode = false;
    }
    public void Textbox1_Change(object source, EventArgs e)
    {
        if (_changeByCode)
            return;
         //do your validation here.
    }
