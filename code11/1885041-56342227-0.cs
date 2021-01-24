    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = GetData();
            GridView1.DataBind();
        }
        private List<Log> GetData()
        {
            List<Log> logs = new List<Log>();
            logs.Add(new Log()
            {
                PDO = "test",
                ID = 100,
                HOSTAME = "test",
                SEVERITY = 5,
                TIMESTAMP = DateTime.Now,
                MESSAGE = "number",
            });
            return logs;
        }
    }
    public class Log
    {
        public int ID { get; set; }
        public string PDO { get; set; }
        public string LOCATION { get; set; }
        public string HOSTAME { get; set; }
        public int SEVERITY { get; set; }
        public DateTime TIMESTAMP { get; set; }
        public string MESSAGE { get; set; }
    }
