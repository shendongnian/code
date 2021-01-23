    public Class foo
    {
        public foo()
        {
            myclass = new myclass(param)
            new Action( () => myclass.initiateState() ).BeginInvoke(initiateStateFinished, null)
        }
    
       private void initiateStateFinished(IAsyncResult ar)
       {
          val = myclass.getValues();
          //other actions
       }
    }
