    static class DSet
    {
        public static DataSet ToDataSet<T>(this IList<T> list)
        {
            Type elementType = typeof(T);
            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);
            //add a column to table for each public property on T
            foreach (var propInfo in elementType.GetProperties())
            {
                t.Columns.Add(propInfo.Name, propInfo.PropertyType);
            }
            //go through each property on T and add each value to the table
            foreach (T item in list)
            {
                DataRow row = t.NewRow();
                foreach (var propInfo in elementType.GetProperties())
                {
                    row[propInfo.Name] = propInfo.GetValue(item, null);
                }
            }
            return ds;
        }
    }
    public class Wrapper
    {
        [JsonProperty("results")]
        public DataSet DataSet { get; set; }
    }
    public class Result
    {
        public string category { get; set; }
        public string type { get; set; }
        public string difficulty { get; set; }
        public string question { get; set; }
        public string correct_answer { get; set; }
        public List<string> incorrect_answers { get; set; }
    }
    public class RootObject
    {
        public int response_code { get; set; }
        public List<Result> results { get; set; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            string json = (new WebClient()).DownloadString("https://opentdb.com/api.php?amount=10&type=boolean");
            var ds = JsonConvert.DeserializeObject<RootObject>(json);
            Wrapper wrapper = new Wrapper();
            wrapper.DataSet = ds.results.ToDataSet();
            Console.WriteLine(ds.response_code);
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
