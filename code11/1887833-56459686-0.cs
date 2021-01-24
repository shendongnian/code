    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += async (s, e) =>
            {
                string result = await ConsultaBD();
            };
        }
        public async Task<string> ConsultaBD()
        {
            var influxDbClient = new InfluxDbClient("http://host:8086/", "user", "pass", InfluxDbVersion.v_1_3);
            var query = "SELECT T_PV FROM TFA WHERE time >= '2019-05-21' and time < '2019-05-22' ";
            var response = await influxDbClient.Client.QueryAsync(query, "dbName");
            return (response.ToString());
        }
    }
