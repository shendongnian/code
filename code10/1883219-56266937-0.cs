    private object sync= new object();
    //Called by the framework whenever someone closes a price position
    private void Positions_Closed(PositionClosedEventArgs args)
            {
              lock (sync) {
                 
                  //other stuff this method does
                     
               }
            }
    
    //This method is called by the framework every time a new price comes in
    //This is unpredictable and could be 1ms from "now", 2 seconds from "now", etc.
    protected override void OnTick()
            {
                AnalyzeMarket();
            }
    
         private void AnalyzeMarket()
        {
            //Does a few preliminary logging and other set ups
            lock (sync) {               
                   //Does the brunt of the work
                   //This is the code we want to make sure doesn't
                   //run when a closing event happens. If that means
                   //we have to wait a few "ticks", that's fine.
              
               //Clean up stuff
            }
        }
