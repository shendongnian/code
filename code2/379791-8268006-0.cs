    public event EventHandler ButtonClicked; // this could be named differently obviously
    ...
    public void Button_OnClick(object sender, EventArgs e) // this is the standard "on button click" event handler created using the form editor
    {
        if (ButtonClicked != null)
            ButtonClicked(this, EventArgs.Empty);
    }
