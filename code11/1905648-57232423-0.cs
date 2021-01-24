     private class I2C
     {
         public I2C()
         {
	     }
			
	     public void RunBase(Action execute)
		 {
			execute.Invoke();
		 }
        }
