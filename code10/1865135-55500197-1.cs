    public class ClsMain
    {
        public event LogHandler OnDataRetrieved;
        public void ReadData()
        {
            ClsSub sub = new ClsSub();
            sub.OnDataRetrieved += OnDataRetrieved;
            sub.LoadData();
        }
    }
