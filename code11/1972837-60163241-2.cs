      class Program
    {
        static void Main(string[] args)
        {
            string sampleString = "[{\"id\":\"1\",\"status\":302},{\"id\":\"2\",\"status\":302},{\"id\":\"3\",\"status\":302},{\"id\":\"4\",\"status\":302}]";
            List<StatusObj> obj = JsonConvert.DeserializeObject<List<StatusObj>>(sampleString);
            foreach (var item in obj)
            {
                var id = item.id;
                var status = item.status;
            }
        }
    }
    public class StatusObj
    {
        public string id { get; set; }
        public int status { get; set; }
    }
