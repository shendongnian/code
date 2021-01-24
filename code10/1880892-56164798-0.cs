    public partial class FrmItemSearch : Form
    {
          private FrmMasterItem f_mb;
          public FrmItemSearch(FrmMasterItem fmb)
          {
                f_mb = fmb;
                InitializeComponent();
          }
    
          private void FrmItemSearch_Load(object sender, EventArgs e)
          {
                ataGridView1.DataSource = DAL.GetSourceFromDatabase(DAL.query);
          }
    }
    public static class DAL
    {
        public static string query = "MyQuery"
    
        public static BindingSource GetSourceFromDatabase(string query)
        {
            MySqlConnection conn = DBUtils.GetDbConnection();
            conn.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = dt;
            return dt;
        }
    }
