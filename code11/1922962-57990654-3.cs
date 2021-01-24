    bool firstkeyisOn = false;
    private void ListOnKeyDown(object sender, KeyEventArgs e)
    {
        if (e.SystemKey==Key.LeftCtrl/*Or other key by choice*/)
        {
    		firstkeyisOn = true;
            e.Handled = true;
            return;
        }
    	if(firstkeyisOn  && (e.Key == Key.Oem3/*Or other key by choice*/))
    	{
    		m_host.SelectNext();
    	}
    }
    private void ListOnKeyUp(object sender, KeyEventArgs e)
    {
        if (e.SystemKey==Key.LeftCtrl/*Key must be same as holding one*/)
        {
    		firstkeyisOn = false;
        }
        //or
        //firstkeyisOn = false;
    }
