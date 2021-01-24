namespace UDDKT
{
    public partial class Form2 : Form
    {
        DataSet ds = new DataSet();
        SqlDataAdapter DaDavaoci = new SqlDataAdapter();
        SqlDataAdapter DaAkcije = new SqlDataAdapter();
        SqlConnection cs = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\UDDKT.mdf;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            SqlCommand SlctDavaoci = new SqlCommand("SELECT * FROM Davaoci", cs);
            DaDavaoci.SelectCommand = SlctDavaoci;
            DaDavaoci.Fill(ds, "TblDavaoci");
            SqlCommand SlctAkcije = new SqlCommand("SELECT * FROM AkcijaDDK", cs);
            DaAkcije.SelectCommand = SlctAkcije;
            DaAkcije.Fill(ds, "TblAkcije");
            DgDavaoci.DataSource = ds.Tables["TblDavaoci"];
            DgAkcije.DataSource = ds.Tables["TblAkcije"];
        }
    }
}
