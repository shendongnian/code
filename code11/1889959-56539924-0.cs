    private int _subscribers;
    private object _sync = new object();
    
    private AddSubscribers()
    {
       Lock(_sync )
       {
           // do what ever you need to do
           _subscribers++;
       }
    }
    
    private RemoveSubscribers()
    {
       Lock(_sync )
       {
           // do what ever you need to do
           _subscribers--;
           if(_subscribers <= 0)
           {
               // cancel token
           }
       }
    }
