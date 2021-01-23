    public void MyForm()
    {
        this.Closing += MyClosingHandler;
        this.Closed += MyClosedHandler;
    }
    private void MyClosingHandler(object sender, System.EventArgs e)
    {
        // Perform work prior to dialog closing (maybe prompting "are you sure?")
    }
    private void MyClosedHandler(object sender, System.EventArgs e)
    {
        // Perform work after the dialog has closed
    }
