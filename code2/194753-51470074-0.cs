    class ListShare 
    {
        public static List<String> DataList { get; set; } = new List<String>();
    }
    class ListUse
    {
        public void AddData()
        {
            ListShare.DataList.Add("content ...");
        }
        public void ClearData()
        {
            ListShare.DataList.Clear();
        }
    }
