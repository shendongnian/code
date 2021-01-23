    {// this is probably your constructor
    .
        public delegate void MyCustomHandler(object sender, EventArgs e);
    .
        MyCustomHandler myCustomHandler = new MyCustomHandler(); //you can do more in your delegates constructor, members etc
        myCustomHandler += btnExit_Click;
        myCustomHandler += btnDisconnect_Click;
    }
    private void btnDisconnect_Click(object sender, EventArgs e) 
    { 
       // do Something
    } 
    private void btnExit_Click(object sender, EventArgs e)
    {
       // do Something
    }
    //And wherever you need to invoke these, you do
    myCustomHandler(object sender, EventArgs e);
