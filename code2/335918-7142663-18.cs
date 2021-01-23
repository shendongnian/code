    public class ExchangeCommonDataSource
    {
        public event EventHandler NewDataReceived;
        public void FireNewDataReceieved()
        {
            if (NewDataReceived != null)
               NewDataReceived();
        }
      
        private string mySomeData1 = "";
        public string SomeData1 
        {
            get
            {
                return SomeData1;
            }
            set
            {
                SomeData1 = value;
                FireNewDataReceieved();
            }
        }
       
        // properties for any other data 
    }
