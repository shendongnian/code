        public delegate MyDelegate(string newValue);
        
       //form
        form_load()
        {
          myControl.MethodDelegate = new MyDelegate(MethodTest);
        }
        
        //Control
        
        someEvent()
        {
           this.MethodDelegate("Test");
        }
