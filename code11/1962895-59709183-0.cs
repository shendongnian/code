    public class DataRecord
    {
        private readonly Dictionary<string, string> data;
        public DataRecord()
        {
            this.data = new Dictionary<string, string>();
        }
        // Access data with names
        public string this[string columnName]
        {
            get{ return data[columnName]; } 
            set{ data[columnName] = value;}
        }
        // Fake properties
        public string PayerAccount
        {
            get => data[nameof(PayerAccount)];
            set => data[nameof(PayerAccount)] = value;
        }
        public string GlobalEntityType
        {
            get => data[nameof(GlobalEntityType)];
            set => data[nameof(GlobalEntityType)] = value;
        }
        public string GlobalEntityNumber
        {
            get => data[nameof(GlobalEntityNumber)];
            set => data[nameof(GlobalEntityNumber)] = value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var record = new DataRecord
            {
                PayerAccount = "10024",
                GlobalEntityType = "QXT",
                GlobalEntityNumber = "509382"
            };
            var number = record["GlobalEntityNumber"];
            // 509382
        }
    }
