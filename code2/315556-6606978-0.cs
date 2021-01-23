            List<Record> list = new List<Record>();
            list.Add(new Record("Apple"));
             list.Add(new Record("Orange"));
            list.Add(new Record("FruitBowl_Outside"));
            list.Add(new Record("Banana"));
            list.Add(new Record("Grape"));
            list.Add(new Record("FruitBowl_Inside"));
            list.Sort(new RecordComparer());
    public class Record {
        public Record(string data) {
            this.data = data;
        }
        private string data;
        public string Data {
            get { return data; }
            set {
                data = value;
            }
        }
    }
    public class RecordComparer : IComparer<Record> {
        public int Compare(Record x, Record y) {
            if(x.Data.Contains("FruitBowl") && !y.Data.Contains("FruitBowl"))
                return 1;
            if(y.Data.Contains("FruitBowl") && !x.Data.Contains("FruitBowl"))
                return -1;
            return x.Data.CompareTo(y.Data);
        }
    }
