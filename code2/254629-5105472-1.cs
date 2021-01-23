    public delegate void MyIndexChangedDelegate(string value);
    public event MyIndexChangedDelegate MyEvent;
    protected void myDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        MyEvent(myDropDown.SelectedValue); // Or whatever you want to work with.
    }
