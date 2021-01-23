    class test
    {
    
    	int[] e = new int[5];
    	public void Hello(int index)
    	{
    		for (int i = 0; i <= 4; i++) {
    			// will always happen if index != 0
    			if (i + index > 4) {
    				MsgBox("Original code would have overwritten memory. .Net will now blow up.");
    			}
    			e[i + index] = i;
    		}
    	}
    
    	public int e1 {
    		get { return e[0]; }
    		set { e[0] = value; }
    	}
    
    	public int e2 {
    		get { return e[1]; }
    		set { e[1] = value; }
    	}
    
    	//' ETC etc etc with e3-e5 ...
    
    }
