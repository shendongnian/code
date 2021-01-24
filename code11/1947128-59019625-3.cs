    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cvyc8\Documents\Test.mdf;Integrated Security=True;Connect Timeout=30"); // this can be the default ctor.
        int Id = 0;
        public Form1()
        {
            InitializeComponent();
            
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        }
