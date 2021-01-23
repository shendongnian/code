    public MyForm() {
        // ...
        HelloWorldButton.Click += new EventHandler(HelloWorldClickEventHandler);
    }
   
    private void HelloWorldClickEventHandler(object sender, EventArgs e)
    {
        // some code
    }
