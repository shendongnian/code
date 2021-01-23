    public void call2()
    {
       call1();
       // rest of call2's logic
    }
    
    private boolean call1Called = false;
    pubic void call1()
    {
       if (!call1Called)
       {
          call1Called=true;
          call1Impl();
       }
       
    }
