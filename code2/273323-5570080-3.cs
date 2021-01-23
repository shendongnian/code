    class DataCollection
    {
        public  IList<Data> List = new List<Data>();
    
        public void ProcessData()
        {
            foreach (var d in List)
            {
                d.Process();
            }
        }
    
    }
