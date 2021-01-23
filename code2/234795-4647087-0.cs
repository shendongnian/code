    using (MyThing thing = new MyThing(_config))
    {
    
    } 
    
    class MyThing {
      public MyThing() {
        //default constructor
      }
    
      public MyThing(Config config) :this() {
        if (config == null)
        {
             //do nothing, default constructor did all the work already
        }
        else
        {
             //do additional stuff with config
        }
      }
    }
