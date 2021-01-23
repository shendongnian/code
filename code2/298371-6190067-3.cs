    public class MyClassWithEvent
    {
        public delegate void DataArrivedDelegate(string data);
        public event DataArrivedDelegate DataArrived;
    
        public void GetSomeData()
        {
            // Communication code goes here; stringData has the data
    
            DataArrivedDelegate handler = DataArrived;
            if (handler != null)
            {
                // If you want to raise the event on this thread, this is fine
                handler(stringData);
            }
        }
    }
