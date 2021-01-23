    public class MyArgs : EventArgs
        {
            //Declare any specific type here
            public string ResultToPass { get; private set; }
            public MyArgs()
            {
            }
        }
    
    if (this.ResultUpdated != null) this.ResultUpdated(this, new MyArgs(){ResultToPass="Your actual result"} );
