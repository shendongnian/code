     private readonly object taskLock = new object();
     void OnEvent1(EventArgs e)
     {
         lock (taskLock)
	     {
	        A();
	     }
     }
    
     void OnEvent2(EventArgs e)
     {
         lock (taskLock)
	     {
	        A();
	     }
     }
     void A()
     {
        // logic
     }
