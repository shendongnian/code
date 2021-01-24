    public class Data
    {
        public string ID { get; set; }
        public string Description { get; set; }
    }
    public delegate void LogHandler(Data log);
    public class ClsSub
    {
        public event LogHandler OnDataRetrieved;
        public void LoadData()
        {
            DataTable dt = GetData();
            Data logdata = new Data();
            foreach (DataRow row in dt.Rows)
            {
                logdata.ID = row["UserID"].ToString();
                logdata.Description = row["Description"].ToString();
                if (OnDataRetrieved != null)
                {
                    OnDataRetrieved(logdata);
                }
            }
        }
        private DataTable GetData()
        {
            var result = new DataTable();
            result.Columns.Add("UserID", typeof(string));
            result.Columns.Add("Description", typeof(string));
            result.Rows.Add("user1", "description1");
            result.Rows.Add("user2", "description2");
            return result;
        }
    }
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
    public class Program
    {
        static void Main(string[] args)
        {
            ClsMain main = new ClsMain();
            main.OnDataRetrieved += ClsApplication_OnDataRetrieved;
            main.ReadData();
            Console.ReadKey();
        }
        private static void ClsApplication_OnDataRetrieved(Data log)
        {
            Console.WriteLine(log.ID + " " + log.Description);
        }
    }
