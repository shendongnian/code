    public delegate void MyIndexChangedDelegate(object sender, EventArgs e);
    public event MyIndexChangedDelegate MyEvent;
    protected void myDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        MyEvent(sender, e);
    }
