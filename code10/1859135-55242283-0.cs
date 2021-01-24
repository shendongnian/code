    static Queue<byte> myQueue = new Queue<byte>();
        
    void Update()
    {
        Debug.Log("datalength: " + data.Length);
        
    	for (int i = 0; i < data.Length; i++)
        {
            myQueue.Enqueue(data[i]);        
        }
    	
    	if (myQueue.Count == 20)
        {
    	    
    		byte[] byteArray = new byte[myQueue.Count];
            for (int i = 0; i < byteArray.Length; i++)
            {
                byteArray[i] = myQueue.Dequeue();
            }
    		
    		Debug.Log("byteArrayLength: " + byteArray.Length);
        	char[] charArray = System.Text.Encoding.UTF8.GetString(byteArray, 0, byteArray.Length).ToCharArray();
        	string s = PrintCharArray(charArray);
    		
        }    
    }
