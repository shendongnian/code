    // ONE WAY
    public void MyMetohd(Somestatus status)
    {
    	switch(status)
    	{
    		case Somestatus.Enum5:
    		     doA();
    		     if(status == Somestatus.Enum5)break;
    		case Somestatus.Enum4:
    		     doB();
    		     if(status == Somestatus.Enum4)break;
    		//... and so on...
    	}
    }
    
    // ANOTHER WAY
    public void MyMetohd(Somestatus status)
    {
    	switch(status)
    	{
    		case Somestatus.Enum1:
    		     do_("ABCDE");
    		     break;
    		case Somestatus.Enum2:
    		     do_("ABCD");
    		     // and so on...
            }
    }
    
    public static void do_(string s)
    {
    	foreach(char ch in s)
    	{
    		switch(ch)
    		{
    			case 'A':
    			     doA();
    			     break;
    			case 'B':
    			     doB();
    			     break;
    			case 'C':
    			     doC();
    			     break;
    			case 'D':
    			     doD();
    			     break;
    			case 'E':
    			     doE();
    			     break			     
    		}
    	}
    }
