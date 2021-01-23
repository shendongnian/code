    class Main
    {
    
         public Main()
         {
             StrClass str = new StrClass(this.Handler);
         }
    
         public void Handler ( )
         {
             //called from recieve data
         }
    }
    
    class StrClass
    {
        readonly Action _handler;
        public StrClass ( Action callback)
        {
            // save the object
            this._handler = callback;
        }
    
        public void receiveData( string str )
        {
            this._handler();
        }
    }
