    class Program
    {
        static void Main(string[] args)
        {
            List<OldData> oldItems = new List<OldData>();
            OldData oldData1 = new OldData();
            oldData1.Name = "Test01";
            oldData1.OriginalPath = "D:/Temp01";
            oldItems.Add(oldData1);
            OldData oldData2 = new OldData();
            oldData2.Name = "Test02";
            oldData2.OriginalPath = "D:/Temp02";
            oldItems.Add(oldData2);
            List<NewData> newItems = new List<NewData>();
            NewData newData1 = new NewData();
            newData1.Name = "Test01";
            newData1.OriginalPath = "D:/Temp01";
            newItems.Add(newData1);
            NewData newData2 = new NewData();
            newData2.Name = "Test05";
            newData2.OriginalPath = "D:/Temp05";
            newItems.Add(newData2);
            oldItems = oldItems.Where(x => newItems != null && !newItems.Any(y => x.Name == y.Name && x.OriginalPath == y.OriginalPath)).ToList();
        }
    }
    class OldData
    {
        public string Name { get; set; }
        public string OriginalPath { get; set; }
    }
    class NewData
    {
        public string Name { get; set; }
        public string OriginalPath { get; set; }
    }
