    protected override void OnControlAdded(ControlEventArgs e)
    {
         // subscribe to click event of e.Control
         e.Control.Click += OnChildClicked;
    }
    // TODO: de-subscribe in OnControlRemoved
    public void OnChildClicked(object Sender, EventArgs e)
    {
        // Clicked on child control, act as if Clicked on me
        this.OnClick(e);
    }
