    class MyClass 
    {
        public event EventHandler TheEvent;
    
        void TestIt()
        {
        	TheEvent += (sender, eventargs) => 
                {
        		Console.WriteLine("Handled!"); // do something in the handler
        	
                // get a delegate representing this anonymous function we are in
        		var fn = (EventHandler)Delegate.CreateDelegate(
                                 typeof(EventHandler), sender, 
                                 (MethodInfo)MethodInfo.GetCurrentMethod());
                // unregister this lambda when it is run
        		TheEvent -= fn;
        	};
        	
        		
            // first time around this will output a line to the console
        	TheEvent(this, EventArgs.Empty);
            // second time around there are no handlers attached and it will throw a NullReferenceException
        	TheEvent(this, EventArgs.Empty);
        }
        
    }
