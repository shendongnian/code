    private void AddVisibleChangedEventHandler()
    {
        this.VisibleChanged += MyVisibleChangedHandler;
    }
    private void MyVisibleChangedHandler(object sender, EventArgs e)
    {
        MessageBox.Show("Visible change event raised!!!");
    }
