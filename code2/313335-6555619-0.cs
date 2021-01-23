    private void myBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        myBrowser1.Document.GetElementsByTagName("body")[0].AttachEventHandler("oncopy", SayHello);
    }
    public void SayHello(object obj,EventArgs e)
    {
        MessageBox.Show("Hello"); //Do your stuff here.
    }
