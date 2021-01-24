    public void BS()
    {
    	bool key = true;
    	while (key)
    	{
    		Process[] pname = Process.GetProcessesByName("appname");
    		if (pname.Length != 0)
    		{
    			textBox1.Text += "run";
    		}
    		else
    		{
    			key = false;
    			textBox1.Text += "stop";
    		}
    		System.Threading.Thread.Sleep(1000); //For 1 Second
    	}
    }
