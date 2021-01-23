    public class ReceiveData
    {
        private List<string> TheList = new List<string>
        {
            "1", "2", "3"
        };
        dynamic provider = new ExpandoObject();
        public void ResponseData()
        {
            foreach (string anItem in TheList)
            {
                // AllData function is declared in class DataProvider
                Func<string, string> asyncAllData = provider.AllData;
                asyncAllData.BeginInvoke(anItem, AllDataDone, null);
            }
            //do something
        }
        private void AllDataDone(IAsyncResult iar)
        {
            AsyncResult ar = (AsyncResult)iar;
            var del = (Func<string, string>)ar.AsyncDelegate;
            // here's your result
            string result = del.EndInvoke(iar);
        }
    }
