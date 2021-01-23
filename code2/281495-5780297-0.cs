    Object _lock = new Object();
    int ktory=0;
    ...
    private void test_proxy()
    {
       try
       {
         int ile = p_listbox.Items.Count;
    
         string proxy = null;
         //'ktory' - means position in listbox
         lock (_lock) {
           proxy = p_listbox.Items[ktory].ToString();
           ktory += 1;
         }
    ...
