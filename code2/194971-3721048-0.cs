    private delegate void AddItemCallback(object o);
    
    private void AddItem(object o)
    {
        if (this.listView.InvokeRequired)
        {
            AddItemCallback d = new AddItemCallback(AddItem);
            this.Invoke(d, new object[] { o });
        }
        else
        {
            // code that adds item to listView (in this case $o)
        }
    }
